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


    }
}
