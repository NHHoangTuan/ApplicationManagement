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


                ApplicationDTO app = new ApplicationDTO()
                {
                    
                    FormID = formID,
                    Candidate = candidate,
                    Position = position,
                    Note = note,
                    Validity = validity,
                    Enterprise = enterprise
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
            var query = "delete from PDK_UNGTUYEN where MaPhieu = @formID";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@formID", r.FormID);
            command.ExecuteNonQuery();


        }


    }
}
