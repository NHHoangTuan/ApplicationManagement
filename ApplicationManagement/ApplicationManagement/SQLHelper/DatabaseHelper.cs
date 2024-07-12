using ApplicationManagement.Config;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ApplicationManagement.DAO
{

    public class SqlConnectionData
    {

        public static bool isSelectedDatabase = false;

        // Tạo chuỗi kết nối cơ sở dữ liệu 
        public static SqlConnection Connect()
        {
            string? server = AppConfig.GetValue(AppConfig.Server);
            string serverString = "Data Source=" + server;
            string connectionString = serverString + ";Initial Catalog=QLTuyenDung;Integrated Security=True";
            //string connectionString = "Data Source=localhost;Initial Catalog=QLTuyenDung1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString); // khởi tạo connect
            return connection;
        }

        public SqlConnectionData()
        {
            SqlConnection connection = SqlConnectionData.Connect();
            try
            {
                connection.Open();
                isSelectedDatabase = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot connect to database. Reason: {ex.Message}");
            }
        }
    }

    internal class DatabaseHelper
    {
        public static string CheckLoginDTO(Account account)
        {
            string user = null;
            // Hàm connect đến CSDL
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            SqlCommand command = new SqlCommand("procLogin", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue(@"user", account.Username);
            command.Parameters.AddWithValue(@"pass", account.Passwords);
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetInt32(3).ToString();
                }
                reader.Close();
                connection.Close();
            }
            else
            {
                return "false_username_or_password";
            }
            return user;
        }

        public List<CandidateDTO> GetCandidates()
        {
            List<CandidateDTO> candidates = new List<CandidateDTO>();

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            string query = "SELECT Ten, CCCD, GioiTinh, NgaySinh, SDT FROM HSUV";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CandidateDTO candidate = new CandidateDTO
                {
                    CandidateName = reader["Ten"].ToString(),
                    CCCD = reader["CCCD"].ToString(),
                    Gender = reader["GioiTinh"].ToString(),
                    DateOfBirth = reader["NgaySinh"].ToString(),
                    PhoneNumber = reader["SDT"].ToString(),
                };
                candidates.Add(candidate);
            }

            reader.Close();
            connection.Close();

            return candidates;
        }

    }
}