using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DAO
{
    internal class ApplicationDAO : DatabaseHelper
    {

        public int insertApplication(ApplicationDTO application)
        {
            // insert to SQL
            var sqlquery = "insert into PDK_UNGTUYEN (MaNV, CCCD, ViTri, TinhHopLe, GhiChu)" +
                "values (@maNV, @cccd, @position, @validity, @note)";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);

            command.Parameters.AddWithValue("@maNV", "1");
            command.Parameters.AddWithValue("@cccd", application.Candidate.CCCD);
            command.Parameters.AddWithValue("@position", application.Position);
            command.Parameters.AddWithValue("@validity", application.Validity);
            command.Parameters.AddWithValue("@note", application.Note == null ? "..." : application.Note);
            

            command.ExecuteNonQuery();


            // select SQL
            int id = -1;
            string sql1 = "SELECT TOP 1 MaPhieu FROM PDK_UNGTUYEN ORDER BY MaPhieu DESC ";

            var command1 = new SqlCommand(sql1, connection);

            var reader = command1.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["MaPhieu"];
            }

            reader.Close();

            return id;


        }



        public BindingList<ApplicationDTO> getAllApplication()
        {
            var sqlquery = @"
            SELECT 
                *
            FROM 
                PDK_UNGTUYEN
            JOIN 
                HSUV on PDK_UNGTUYEN.CCCD = HSUV.CCCD";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);
            var reader = command.ExecuteReader();

            BindingList<ApplicationDTO> list = new BindingList<ApplicationDTO>();
            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();
            CandidateDAO candidateDAO = new CandidateDAO();
            BrowseProfileDAO browseProfileDAO = new BrowseProfileDAO();

            while (reader.Read())
            {
                var cccd = (string)reader["CCCD"];
                var candidate = candidateDAO.getCandidateByID(cccd);
                var position = (string)reader["ViTri"];
                var note = (string)reader["GhiChu"];
                var formID = (int)reader["MaPhieu"];
                var validity = (string)reader["TinhHopLe"];
                var enterprise = browseProfileDAO.getEnterpriseByApplicationFormID(formID);
                var CVPath = reader["CVPath"] == DBNull.Value ? null : (string?)reader["CVPath"];


                ApplicationDTO app = new ApplicationDTO()
                {
                    
                    FormID = formID,
                    Candidate = candidate,
                    Position = position,
                    Note = note,
                    Validity = validity,
                    Enterprise = enterprise,
                    CVPath = CVPath,
                };

                list.Add(app);
            }
            reader.Close();
            return list;
        }



        public void updateApplicationStatus(ApplicationDTO application)
        {
            var query = "update PDK_UNGTUYEN set TinhHopLe = @validity where MaPhieu = @formID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@formID", application.FormID);
            command.Parameters.AddWithValue("@validity", application.Validity);

            command.ExecuteNonQuery();
        }


        public void deleteApplication(ApplicationDTO r)
        {

            var query0 = "delete from DUYETHOSO where MaPhieuUT = @formID";
            var query = "delete from PDK_UNGTUYEN where MaPhieu = @formID";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();


            var command0 = new SqlCommand(query0, connection);

            command0.Parameters.AddWithValue("@formID", r.FormID);
            command0.ExecuteNonQuery();

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@formID", r.FormID);
            command.ExecuteNonQuery();


        }



        // lay danh sach ung tuyen da duoc nhan vien duyet de hien thi cho nha tuyen dung xem va duyet
        // nghia la co tinh hop le cua PDK_UNGTUYEN la OK va co TrangThai cua PHEDUYET la 0
        public BindingList<ApplicationDTO> getAllApplicationByEnterprise(string maThue)
        {
            var sqlquery = @"
            	SELECT 
    PDK_QUANGCAO.MaThue, HSUV.CCCD, ViTri, GhiChu, PDK_UNGTUYEN.MaPhieu, TinhHopLe, PDK_UNGTUYEN.CVPath
FROM 
    PDK_UNGTUYEN
JOIN 
    HSUV on PDK_UNGTUYEN.CCCD = HSUV.CCCD join DUYETHOSO on DUYETHOSO.MaPhieuUT = PDK_UNGTUYEN.MaPhieu
	join PDK_QUANGCAO on PDK_QUANGCAO.MaPhieu = DUYETHOSO.MaPhieuQC
    join PHEDUYET on PHEDUYET.MaPhieuUT = PDK_UNGTUYEN.MaPhieu
	and TinhHopLe = 'OK' and PDK_QUANGCAO.MaThue = @maThue and TrangThai = 0";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);

            command.Parameters.AddWithValue("@maThue", maThue);
            command.ExecuteNonQuery();

            var reader = command.ExecuteReader();

            BindingList<ApplicationDTO> list = new BindingList<ApplicationDTO>();
            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();
            CandidateDAO candidateDAO = new CandidateDAO();
            BrowseProfileDAO browseProfileDAO = new BrowseProfileDAO();

            while (reader.Read())
            {
                var cccd = (string)reader["CCCD"];
                var candidate = candidateDAO.getCandidateByID(cccd);
                var position = (string)reader["ViTri"];
                var note = (string)reader["GhiChu"];
                var formID = (int)reader["MaPhieu"];
                var validity = (string)reader["TinhHopLe"];
                var enterprise = browseProfileDAO.getEnterpriseByApplicationFormID(formID);
                var CVPath = reader["CVPath"] == DBNull.Value ? null : (string?)reader["CVPath"];


                ApplicationDTO app = new ApplicationDTO()
                {

                    FormID = formID,
                    Candidate = candidate,
                    Position = position,
                    Note = note,
                    Validity = validity,
                    Enterprise = enterprise,
                    CVPath = CVPath,
                };

                list.Add(app);
            }
            reader.Close();
            return list;
        }



        public BindingList<ApplicationDTO> getAllResultForCandidate(string userID)
        {
            var sqlquery = @"
            		            	SELECT 
    PDK_QUANGCAO.MaThue, HSUV.CCCD, ViTri, GhiChu, PDK_UNGTUYEN.MaPhieu, TinhHopLe, TrangThai, PDK_UNGTUYEN.CVPath
FROM 
    PDK_UNGTUYEN
JOIN 
    HSUV on PDK_UNGTUYEN.CCCD = HSUV.CCCD join DUYETHOSO on DUYETHOSO.MaPhieuUT = PDK_UNGTUYEN.MaPhieu
	join PDK_QUANGCAO on PDK_QUANGCAO.MaPhieu = DUYETHOSO.MaPhieuQC
    join PHEDUYET on PHEDUYET.MaPhieuUT = PDK_UNGTUYEN.MaPhieu
	and TinhHopLe = 'OK'  and TrangThai = 1 and HSUV.CCCD = @userID";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);

            command.Parameters.AddWithValue("@userID", userID);
            command.ExecuteNonQuery();

            var reader = command.ExecuteReader();

            BindingList<ApplicationDTO> list = new BindingList<ApplicationDTO>();
            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();
            CandidateDAO candidateDAO = new CandidateDAO();
            BrowseProfileDAO browseProfileDAO = new BrowseProfileDAO();

            while (reader.Read())
            {
                var cccd = (string)reader["CCCD"];
                var candidate = candidateDAO.getCandidateByID(cccd);
                var position = (string)reader["ViTri"];
                var note = (string)reader["GhiChu"];
                var formID = (int)reader["MaPhieu"];
                var validity = (string)reader["TinhHopLe"];
                var enterprise = browseProfileDAO.getEnterpriseByApplicationFormID(formID);
                var CVPath = reader["CVPath"] == DBNull.Value ? null : (string?)reader["CVPath"];


                ApplicationDTO app = new ApplicationDTO()
                {

                    FormID = formID,
                    Candidate = candidate,
                    Position = position,
                    Note = note,
                    Validity = validity,
                    Enterprise = enterprise,
                    CVPath = CVPath,
                };

                list.Add(app);
            }
            reader.Close();
            return list;
        }




        public void updateCVPath(int maPhieu, string cvPath)
        {
            // update SQL
            string sql = $"""
                update PDK_UNGTUYEN 
                set CVPath = @cvPath
                where MaPhieu = @maPhieu
                """;

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@maPhieu", maPhieu);
            command.Parameters.AddWithValue("@cvPath", cvPath);

            command.ExecuteNonQuery();
        }


    }
}
