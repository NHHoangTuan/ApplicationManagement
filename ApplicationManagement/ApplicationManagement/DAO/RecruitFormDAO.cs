using ApplicationManagement.DTO;
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

            connection.Close();
        }



        public BindingList<RecruitmentDTO> getAllRecruitment()
        {
            var sqlquery = @"
            SELECT 
                DOANHNGHIEP.MaThue,
                PCC_TT_DANGTUYEN.ViTriTuyenDung, 
                PCC_TT_DANGTUYEN.SLTuyenDung, 
                PCC_TT_DANGTUYEN.KTGDangTuyen, 
                PCC_TT_DANGTUYEN.ThongTinYeuCau, 
                DOANHNGHIEP_DANGTUYEN.TGDangTuyen, 
                DOANHNGHIEP_DANGTUYEN.HinhThuc
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
                //var formID = (int)reader["MaPhieu"];
                var taxID = reader["MaThue"] == DBNull.Value ? null : (string?)reader["MaThue"];


                RecruitmentDTO recruitment = new RecruitmentDTO()
                {
                    Vacancies = vacancies,
                    RecruitNumber = recruitNumber,
                    RecruitPeriod = recruitPeriod,
                    Require = require,
                    RecruitForm = recruitForm,
                    RecruitTime = recruitTime,
                    Enterprise = enterpriseDAO.getEnterpriseByTaxID(taxID),
                    

                };

                list.Add(recruitment);
            }
            reader.Close();
            return list;
        }



    }
}
