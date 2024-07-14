using ApplicationManagement.DTO;
using ApplicationManagement.GUI;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ApplicationManagement.DAO {
    internal class EnterpriseDAO : DatabaseHelper {
        public void AddEnterpriseAccount(EnterpriseDTO enterprise, string username, string password) {
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            //Add TAIKHOAN
            string query = "INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) VALUES (@AccountID, @Username, @Password, @PermissionLevel)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", enterprise.TaxID);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@PermissionLevel", 2);
            command.ExecuteNonQuery();

            //Add DOANHNGHIEP
            using (SqlCommand command1 = new SqlCommand("AddDoanhNghiep", connection))
            {
                command1.CommandType = System.Data.CommandType.StoredProcedure;
                command1.Parameters.AddWithValue("@MaThue", enterprise.TaxID);
                command1.ExecuteNonQuery();
            }

            //Add PDK_THONGTIN
            using (SqlCommand command2 = new SqlCommand("AddPDKThongTin", connection))
            {
                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@TenCTy", enterprise.EnterpriseName);
                command2.Parameters.AddWithValue("@MaThue", enterprise.TaxID);
                command2.Parameters.AddWithValue("@MaNV", 1);
                command2.Parameters.AddWithValue("@NguoiDaiDien", enterprise.Leader);
                command2.Parameters.AddWithValue("@DiaChi", enterprise.Address);
                command2.Parameters.AddWithValue("@Email", enterprise.Email);
                command2.ExecuteNonQuery();
            }

            connection.Close();
        }



        public BindingList<EnterpriseDTO> getAllEnterprise()
        {
            BindingList<EnterpriseDTO> list = new BindingList<EnterpriseDTO>();

            var sql1 = "select TenCty, NguoiDaiDien, DiaChi, Email, DOANHNGHIEP.MaThue, LogoPath " +
                "from PDK_THONGTIN join DOANHNGHIEP on PDK_THONGTIN.MaThue = DOANHNGHIEP.MaThue";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);

            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                var TaxID = (string)reader1["MaThue"];
                var EnterpriseName = (string)reader1["TenCty"];
                var Leader = (string)reader1["NguoiDaiDien"];
                var Address = (string)reader1["DiaChi"];
                var Email = (string)reader1["Email"];
                var LogoPath = (string)reader1["LogoPath"];

                EnterpriseDTO newEnterprise = new EnterpriseDTO()
                {
                    TaxID = TaxID,
                    EnterpriseName = EnterpriseName,
                    Leader = Leader,
                    Address = Address,
                    Email = Email,
                    LogoPath = LogoPath
                };

                list.Add(newEnterprise);


            }

            reader1.Close();
            connection.Close();

            return list;
        }


        public EnterpriseDTO getEnterpriseByTaxID(string taxID)
        {
            var sql1 = "select TenCty, NguoiDaiDien, DiaChi, Email, DOANHNGHIEP.MaThue, LogoPath " +
                "from PDK_THONGTIN join DOANHNGHIEP on PDK_THONGTIN.MaThue = DOANHNGHIEP.MaThue where DOANHNGHIEP.MaThue = @taxID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@taxID", taxID);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();
            var enterprise = new EnterpriseDTO();
            while (reader1.Read())
            {
                enterprise.TaxID = taxID;
                enterprise.EnterpriseName = (string)reader1["TenCty"];
                enterprise.Leader = (string)reader1["NguoiDaiDien"];
                enterprise.Address = (string)reader1["DiaChi"];
                enterprise.Email = (string)reader1["Email"];
                enterprise.LogoPath = (string)reader1["LogoPath"];
            }

            return enterprise;
        }


        public void updateImage(string taxID, string key)
        {
            // update SQL
            string sql = $"""
                update DOANHNGHIEP 
                set LogoPath = 'D:\App\CV_Uploaded\{key}\.png'
                where MaThue = {taxID}
                """;

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }


    }
}
