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
                command2.Parameters.AddWithValue("@TenCTy", enterprise.Name);
                command2.Parameters.AddWithValue("@MaThue", enterprise.TaxID);
                command2.Parameters.AddWithValue("@MaNV", 1);
                command2.Parameters.AddWithValue("@NguoiDaiDien", enterprise.Leader);
                command2.Parameters.AddWithValue("@DiaChi", enterprise.Address);
                command2.Parameters.AddWithValue("@Email", enterprise.Email);
                command2.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
