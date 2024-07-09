using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO {
    internal class CandidateDAO : DatabaseHelper {
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

        public void AddCandidateAccount(string username, string password, CandidateDTO candidate) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            /*// Bước 1: Tìm AccountID lớn nhất hiện có
            string getMaxIdQuery = "SELECT ISNULL(MAX(CAST(MaTK AS INT)), 0) FROM TAIKHOAN";
            SqlCommand getMaxIdCommand = new SqlCommand(getMaxIdQuery, connection);
            int maxId = Convert.ToInt32(getMaxIdCommand.ExecuteScalar());

            // Bước 2: Tạo AccountID mới
            int newAccountId = maxId + 1;*/




            string query = "INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) VALUES (@AccountID, @Username, @Password, @PermissionLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", candidate.CCCD);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@PermissionLevel", 3);
            command.ExecuteNonQuery();

            connection.Close();
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
