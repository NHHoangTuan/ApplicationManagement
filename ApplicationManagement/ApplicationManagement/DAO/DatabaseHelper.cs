using ApplicationManagement.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO {
    public class DatabaseHelper {
        private string connectionString;

        public DatabaseHelper() {
            connectionString = "Data Source=MSI\\TENT;Initial Catalog=QLTuyenDung;Integrated Security=True";
        }

        public List<CandidateDTO> GetCandidates() {
            List<CandidateDTO> candidates = new List<CandidateDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT Ten, CCCD, GioiTinh, NgaySinh, SDT FROM HSUV";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
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
            }

            return candidates;
        }
    }
}
