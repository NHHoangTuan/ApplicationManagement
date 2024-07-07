using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO {

    public class SqlConnectionData {
        // Tạo chuỗi kết nối cơ sở dữ liệu 
        public static SqlConnection Connect() {
            string connectionString = "Data Source=MSI\\TENT;Initial Catalog=QLTuyenDung;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString); // khởi tạo connect
            return connection;
        }
    }

    internal class DatabaseHelper {
        public static string CheckLoginDTO(Account account) {
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
            if (reader.HasRows) {
                while (reader.Read()) {
                    user = reader.GetInt32(3).ToString();
                }
                reader.Close();
                connection.Close();
            }
            else {
                return "false_username_or_password";
            }
            return user;

        }

        public List<CandidateDTO> GetCandidates() {
            List<CandidateDTO> candidates = new List<CandidateDTO>();

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            string query = "SELECT Ten, CCCD, GioiTinh, NgaySinh, SDT FROM HSUV";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                CandidateDTO candidate = new CandidateDTO {
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

        public void SaveCandidate(CandidateDTO candidate) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            string query = "INSERT INTO HSUV (Ten, CCCD, GioiTinh, NgaySinh, SDT) VALUES (@CandidateName, @CCCD, @Gender, @DateOfBirth, @PhoneNumber)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CandidateName", candidate.CandidateName);
            command.Parameters.AddWithValue("@CCCD", candidate.CCCD);
            command.Parameters.AddWithValue("@Gender", candidate.Gender);
            DateTime dateOfBirth = DateTime.Parse(candidate.DateOfBirth);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@PhoneNumber", candidate.PhoneNumber);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddCandidateAccount(CandidateDTO candidate) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            string query = "INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) VALUES (@AccountID, @Username, @Password, @PermissionLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", candidate.CCCD);
            command.Parameters.AddWithValue("@Username", candidate.CandidateName.ToLower().Trim());
            command.Parameters.AddWithValue("@Password", candidate.PhoneNumber);
            command.Parameters.AddWithValue("@PermissionLevel", 3);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
