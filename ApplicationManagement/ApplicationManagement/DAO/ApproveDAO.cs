using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DAO
{
    class ApproveDAO : DatabaseHelper
    {

        public void insertApprove(int MaPhieuUT, string MaThue)
        {
            // insert to SQL
            var sqlquery = "insert into PHEDUYET (MaPhieuUT, MaThue, TrangThai)" +
                "values (@maPhieuUT, @maThue, @trangthai)";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);


            command.Parameters.AddWithValue("@maPhieuUT", MaPhieuUT);
            //command.Parameters.AddWithValue("@maPhieuTD", MaPhieuTD);
            command.Parameters.AddWithValue("@maThue", MaThue);
            command.Parameters.AddWithValue("@trangthai", 0);


            command.ExecuteNonQuery();


        }


        public void updateApproveStatus(int MaPhieuUT, int status)
        {
            var query = "update PHEDUYET set TrangThai = @status where MaPhieuUT = @maPhieuUT";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@maPhieuUT", MaPhieuUT);
            command.Parameters.AddWithValue ("@status", status);
            //command.Parameters.AddWithValue("@maPhieuTD", MaPhieuTD);

            command.ExecuteNonQuery();
        }

    }
}
