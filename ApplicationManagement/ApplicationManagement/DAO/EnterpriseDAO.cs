using ApplicationManagement.DTO;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO {
    internal class EnterpriseDAO : DatabaseHelper {
        public void AddEnterpriseAccount(EnterpriseDTO enterprise, string username, string password) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            //Add TAIKHOAN
            string query = "INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) VALUES (@AccountID, @Username, @Password, @PermissionLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", enterprise.TaxID);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@PermissionLevel", 2);
            command.ExecuteNonQuery();

            //Add DOANHNGHIEP
            using (SqlCommand command1 = new SqlCommand("AddDoanhNghiep", connection))
            {
                command1.CommandType = System.Data.CommandType.StoredProcedure;
                command1.Parameters.AddWithValue("@MaThue", enterprise.TaxID);
                command1.ExecuteNonQuery();
            }

            //Add PDK_THONGTIN
            using (SqlCommand command2 = new SqlCommand("AddPDKThongTin", connection))
            {
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@TenCTy", enterprise.EnterpriseName);
                command2.Parameters.AddWithValue("@MaThue", enterprise.TaxID);
                command2.Parameters.AddWithValue("@MaNV", 1);
                command2.Parameters.AddWithValue("@NguoiDaiDien", enterprise.Leader);
                command2.Parameters.AddWithValue("@DiaChi", enterprise.Address);
                command2.Parameters.AddWithValue("@Email", enterprise.Email);
                command2.ExecuteNonQuery();
            }

            connection.Close();
        }

        public EnterpriseDTO getEnterpriseByTaxID(string taxID)
        {
            var sql1 = "select TenCty, NguoiDaiDien, DiaChi, Email from PDK_THONGTIN where MaThue = @taxID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@taxID", taxID);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();
            var enterprise = new EnterpriseDTO();
            while (reader1.Read())
            {
                enterprise.TaxID = taxID;
                enterprise.EnterpriseName = (string)reader1["TenCty"];
                enterprise.Leader = (string)reader1["NguoiDaiDien"];
                enterprise.Address = (string)reader1["DiaChi"];
                enterprise.Email = (string)reader1["Email"];
            }

            return enterprise;
        }
<<<<<<< HEAD



=======
>>>>>>> c2515aed41f5017a1ef8aed04bd03c89da6d0dd2
    }
}
