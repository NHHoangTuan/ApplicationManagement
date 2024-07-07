using ApplicationManagement.DTO;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO {
    internal class EnterpriseDAO : DatabaseHelper {
        public void AddEnterpriseAccount(EnterpriseDTO enterprise) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            string query = "INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) VALUES (@AccountID, @Username, @Password, @PermissionLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", enterprise.TaxID);
            command.Parameters.AddWithValue("@Username", enterprise.Name.ToLower().Trim());
            command.Parameters.AddWithValue("@Password", enterprise.TaxID);
            command.Parameters.AddWithValue("@PermissionLevel", 2);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
