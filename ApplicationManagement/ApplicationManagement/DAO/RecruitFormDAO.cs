using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
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
    }
}
