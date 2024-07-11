using ApplicationManagement.DTO;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DAO
{
    internal class RecruitFormDAO : DatabaseHelper
    {
        public void AddRecruit(RecruitFormDTO recruitForm)
        {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            //Add PCC_TT_DANGTUYEN
            using (SqlCommand command = new SqlCommand("AddPCC_TT_DangTuyen", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViTriTuyenDung", recruitForm.Vacancies);
                command.Parameters.AddWithValue("@SLTuyenDung", recruitForm.Amount);
                command.Parameters.AddWithValue("@KTGDangTuyen", recruitForm.Time);
                command.Parameters.AddWithValue("@ThongTinYeuCau", recruitForm.Description);

                command.ExecuteNonQuery();
            }

            //Get new MaPhieu from PCC_TT_DANGTUYEN
            int maPhieu = 0;
            using (SqlCommand command1 = new SqlCommand(@"SELECT MaPhieu 
                                              FROM PCC_TT_DANGTUYEN 
                                              WHERE ViTriTuyenDung = @ViTriTuyenDung 
                                                AND SLTuyenDung = @SLTuyenDung 
                                                AND KTGDangTuyen = @KTGDangTuyen 
                                                AND ThongTinYeuCau = @ThongTinYeuCau", connection))
            {
                command1.Parameters.AddWithValue("@ViTriTuyenDung", recruitForm.Vacancies);
                command1.Parameters.AddWithValue("@SLTuyenDung", recruitForm.Amount);
                command1.Parameters.AddWithValue("@KTGDangTuyen", recruitForm.Time);
                command1.Parameters.AddWithValue("@ThongTinYeuCau", recruitForm.Description);
                SqlDataReader reader = command1.ExecuteReader();
                if (reader.Read())
                {
                    maPhieu = reader.GetInt32(0);
                }
                reader.Close();
            }

            //Add DOANHNGHIEP_DANGTUYEN
            using (SqlCommand command2 = new SqlCommand("AddDoanhNghiepDangTuyen", connection))
            {
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@MaThue", recruitForm.TaxID);
                command2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                command2.Parameters.AddWithValue("@MaNV", 1);
                command2.Parameters.AddWithValue("@TGDangTuyen", recruitForm.ExactlyDate);
                command2.Parameters.AddWithValue("@HinhThuc", recruitForm.Form);

                command2.ExecuteNonQuery();
            }


            //Add PDK_QUANGCAO
            using (SqlCommand command3 = new SqlCommand("AddPDKQuangCao", connection))
            {
                command3.CommandType = CommandType.StoredProcedure;
                command3.Parameters.AddWithValue("@MaThue", recruitForm.TaxID);
                command3.Parameters.AddWithValue("@MaPhieuDT", maPhieu);
                command3.Parameters.AddWithValue("@MaNV", 1);
                

                command3.ExecuteNonQuery();
            }


            connection.Close();
        }



        public int getAdvertiseByRecruitFormID(int recruitFormID)
        {
            var sql1 = "select MaPhieu from PDK_QUANGCAO where MaPhieuDT = @id";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@id", recruitFormID);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();


            int formID = 0;
            while (reader1.Read())
            {
                formID = (int)reader1["MaPhieu"];
            }
            
             

            return formID;
        }



        public BindingList<RecruitmentDTO> getAllRecruitment()
        {
            var sqlquery = @"
            SELECT 
                DOANHNGHIEP_DANGTUYEN.MaPhieu,
                DOANHNGHIEP.MaThue,
                PCC_TT_DANGTUYEN.ViTriTuyenDung, 
                PCC_TT_DANGTUYEN.SLTuyenDung, 
                PCC_TT_DANGTUYEN.KTGDangTuyen, 
                PCC_TT_DANGTUYEN.ThongTinYeuCau, 
                DOANHNGHIEP_DANGTUYEN.TGDangTuyen, 
                DOANHNGHIEP_DANGTUYEN.HinhThuc,
                DOANHNGHIEP_DANGTUYEN.TinhHopLe
            FROM 
                PCC_TT_DANGTUYEN
            JOIN 
                DOANHNGHIEP_DANGTUYEN ON PCC_TT_DANGTUYEN.MaPhieu = DOANHNGHIEP_DANGTUYEN.MaPhieu
            JOIN 
                DOANHNGHIEP ON DOANHNGHIEP_DANGTUYEN.MaThue = DOANHNGHIEP.MaThue";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);
            var reader = command.ExecuteReader();

            BindingList<RecruitmentDTO> list = new BindingList<RecruitmentDTO>();
            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();

            while (reader.Read())
            {
                var vacancies = (string)reader["ViTriTuyenDung"];
                var recruitNumber = (int)reader["SLTuyenDung"];
                var recruitPeriod = (int)reader["KTGDangTuyen"];
                var require = (string)reader["ThongTinYeuCau"];
                var recruitForm = (string)reader["HinhThuc"];
                var recruitTime = (DateTime)reader["TGDangTuyen"];
                var formID = (int)reader["MaPhieu"];
                var taxID = reader["MaThue"] == DBNull.Value ? null : (string?)reader["MaThue"];
                var validity = (string)reader["TinhHopLe"];


                RecruitmentDTO recruitment = new RecruitmentDTO()
                {
                    Vacancies = vacancies,
                    RecruitNumber = recruitNumber,
                    RecruitPeriod = recruitPeriod,
                    Require = require,
                    RecruitForm = recruitForm,
                    RecruitTime = recruitTime,
                    Enterprise = enterpriseDAO.getEnterpriseByTaxID(taxID),
                    formID = formID,
                    Validity = validity,
                };

                list.Add(recruitment);
            }
            reader.Close();
            return list;
        }



        public void updateRecruitStatus(RecruitmentDTO recruitment)
        {
            var query = "update DOANHNGHIEP_DANGTUYEN set TinhHopLe = @validity where MaPhieu = @formID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@formID", recruitment.formID);
            command.Parameters.AddWithValue("@validity", recruitment.Validity);

            command.ExecuteNonQuery();
        }


        public void deleteRecruit(RecruitmentDTO r)
        {
            var query = "delete from PCC_TT_DANGTUYEN where MaPhieu = @formID";
            var query1 = "delete from DOANHNGHIEP_DANGTUYEN where MaPhieu = @formID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();


            var command1 = new SqlCommand(query1, connection);

            command1.Parameters.AddWithValue("@formID", r.formID);
            command1.ExecuteNonQuery();

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@formID", r.formID);
            command.ExecuteNonQuery();



        }



        // hàm trả về danh sách bài tuyển dụng mà ứng viên hiện tại chưa ứng tuyển
        public BindingList<RecruitmentDTO> getAllRecruitmentByCurrentUserID(string currentUserID)
        {
            var sqlquery = @"
            SELECT 
                DOANHNGHIEP_DANGTUYEN.MaPhieu,
                DOANHNGHIEP.MaThue,
                PCC_TT_DANGTUYEN.ViTriTuyenDung, 
                PCC_TT_DANGTUYEN.SLTuyenDung, 
                PCC_TT_DANGTUYEN.KTGDangTuyen, 
                PCC_TT_DANGTUYEN.ThongTinYeuCau, 
                DOANHNGHIEP_DANGTUYEN.TGDangTuyen, 
                DOANHNGHIEP_DANGTUYEN.HinhThuc,
                DOANHNGHIEP_DANGTUYEN.TinhHopLe
            FROM 
                PCC_TT_DANGTUYEN
            JOIN 
                DOANHNGHIEP_DANGTUYEN ON PCC_TT_DANGTUYEN.MaPhieu = DOANHNGHIEP_DANGTUYEN.MaPhieu
            JOIN 
                DOANHNGHIEP ON DOANHNGHIEP_DANGTUYEN.MaThue = DOANHNGHIEP.MaThue";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);
            var reader = command.ExecuteReader();

            BindingList<RecruitmentDTO> list = new BindingList<RecruitmentDTO>();
            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();

            while (reader.Read())
            {
                var vacancies = (string)reader["ViTriTuyenDung"];
                var recruitNumber = (int)reader["SLTuyenDung"];
                var recruitPeriod = (int)reader["KTGDangTuyen"];
                var require = (string)reader["ThongTinYeuCau"];
                var recruitForm = (string)reader["HinhThuc"];
                var recruitTime = (DateTime)reader["TGDangTuyen"];
                var formID = (int)reader["MaPhieu"];
                var taxID = reader["MaThue"] == DBNull.Value ? null : (string?)reader["MaThue"];
                var validity = (string)reader["TinhHopLe"];


                RecruitmentDTO recruitment = new RecruitmentDTO()
                {
                    Vacancies = vacancies,
                    RecruitNumber = recruitNumber,
                    RecruitPeriod = recruitPeriod,
                    Require = require,
                    RecruitForm = recruitForm,
                    RecruitTime = recruitTime,
                    Enterprise = enterpriseDAO.getEnterpriseByTaxID(taxID),
                    formID = formID,
                    Validity = validity,
                };

                list.Add(recruitment);
            }
            reader.Close();
            return list;
        }
    }
}
