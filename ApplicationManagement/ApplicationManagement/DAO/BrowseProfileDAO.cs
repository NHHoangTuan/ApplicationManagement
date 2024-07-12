using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DAO
{
    internal class BrowseProfileDAO : DatabaseHelper
    {

        public void insertBrowseProfile(int maPhieuQC, int maPhieuUT, DateTime now)
        {
            // insert to SQL
            var sqlquery = "insert into DUYETHOSO (MaPhieuQC, MaPhieuUT, ThoiGian)" +
                "values (@maPhieuQC, @maPhieuUT, @thoigian)";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);

            command.Parameters.AddWithValue("@maPhieuQC", maPhieuQC);
            command.Parameters.AddWithValue("@maPhieuUT", maPhieuUT);
            command.Parameters.AddWithValue("@thoigian", now);

            command.ExecuteNonQuery();


        }


        public EnterpriseDTO getEnterpriseByApplicationFormID(int id)
        {
            var sql1 = "select * from DUYETHOSO join PDK_QUANGCAO on DUYETHOSO.MaPhieuQC = PDK_QUANGCAO.MaPhieu " +
                "join PDK_THONGTIN on PDK_QUANGCAO.MaThue = PDK_THONGTIN.MaThue and DUYETHOSO.MaPhieuUT = @applicationFormID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@applicationFormID", id);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();
            var enterprise = new EnterpriseDTO();
            while (reader1.Read())
            {
                enterprise.TaxID = (string)reader1["MaThue"];
                enterprise.EnterpriseName = (string)reader1["TenCty"];
                enterprise.Leader = (string)reader1["NguoiDaiDien"];
                enterprise.Address = (string)reader1["DiaChi"];
                enterprise.Email = (string)reader1["Email"];
            }

            return enterprise;
        }



        // hàm kiểm tra xem với bài tuyển dụng A thì ứng viên B có ứng tuyển hay chưa
        // nếu trả về list null thì chưa ứng tuyển, trả về list != null thì đã ứng tuyển

        public int getApplicationFormIDWithCurrentUser(int maPhieuDT, string cccd)
        {
            int applicationFormID = -1;


            var sql1 = "select PDK_UNGTUYEN.MaPhieu from PDK_UNGTUYEN join DUYETHOSO on PDK_UNGTUYEN.MaPhieu = DUYETHOSO.MaPhieuUT " +
                "join PDK_QUANGCAO on PDK_QUANGCAO.MaPhieu = DUYETHOSO.MaPhieuQC " +
                "and MaPhieuDT = @maPhieuDT and CCCD = @cccd";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@maPhieuDT", maPhieuDT);
            command1.Parameters.AddWithValue("@cccd", cccd);
            command1.ExecuteNonQuery();


            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                applicationFormID = (int)reader1["MaPhieu"];
                
            }


            return applicationFormID;
        }

    }
}
