using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DAO
{
    internal class AccountDAO : DatabaseHelper
    {

        public bool IsUsernameExist(string username)
        {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            string checkQuery = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenTaiKhoan = @Username";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@Username", username);

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            connection.Close();

            return count > 0;
        }


        public Account getAccountByUsername(string username)
        {
            var sql1 = "select MaTK, MaQuyen from TAIKHOAN where TenTaiKhoan = @username";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@username", username);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();
            var account = new Account();
            while (reader1.Read())
            {
                account.Username = username;
                account.AccountID = (string)reader1["MaTK"];
                account.PermissionLevel = (int)reader1["MaQuyen"];
               
            }

            return account;
        }

    }
}
