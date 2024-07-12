using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationManagement.DAO
{
    internal class BillDAO
    {
        public int AddBill(BillDTO bill)
        {

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO HOADON (MaThue, MaPhieu, SoTien, DaNhan) VALUES (@MaThue, @MaPhieu, @SoTien, @DaNhan); SELECT SCOPE_IDENTITY();", connection))
            {
                command.Parameters.AddWithValue("@MaThue", bill.MaThue);
                command.Parameters.AddWithValue("@MaPhieu", bill.MaPhieu);
                command.Parameters.AddWithValue("@SoTien", bill.SoTien);
                command.Parameters.AddWithValue("@DaNhan", bill.DaNhan);

                bill.MaHoaDon = Convert.ToInt32(command.ExecuteScalar());
            }

            connection.Close();
            return bill.MaHoaDon;
        }

        public BindingList<BillDTO> GetAllBills()
        {
            BindingList<BillDTO> bills = new BindingList<BillDTO>();
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();

            string query = "SELECT MaHoaDon, MaThue, MaPhieu, SoTien, DaNhan FROM HOADON";

            EnterpriseDAO enterpriseDAO = new EnterpriseDAO();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string maThue = (string)reader["MaThue"];

                    BillDTO bill = new BillDTO
                    {
                        MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                        MaThue = maThue,
                        MaPhieu = Convert.ToInt32(reader["MaPhieu"]),
                        SoTien = Convert.ToInt32(reader["SoTien"]),
                        DaNhan = Convert.ToInt32(reader["DaNhan"]),
                        Enterprise = enterpriseDAO.getEnterpriseByTaxID(maThue)
                        
                    };
                    bills.Add(bill);
                }
                reader.Close();
            }

            connection.Close();
            return bills;
        }


        public Dictionary<int, int> GetBillStatuses()
        {
            var sqlquery = @"
        SELECT 
            MaPhieu, 
            DaNhan 
        FROM 
            HOADON";

            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command = new SqlCommand(sqlquery, connection);
            var reader = command.ExecuteReader();

            Dictionary<int, int> billStatuses = new Dictionary<int, int>();
            while (reader.Read())
            {
                var maPhieu = (int)reader["MaPhieu"];
                var daNhan = (int)reader["DaNhan"];
                billStatuses[maPhieu] = daNhan;
            }
            reader.Close();
            connection.Close();

            return billStatuses;
        }

        public void updateDaNhan(BillDTO bill)
        {
            string query = "UPDATE HOADON SET DaNhan = @DaNhan WHERE MaHoaDon = @MaHoaDon";
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", bill.MaHoaDon);
                    command.Parameters.AddWithValue("@DaNhan", bill.DaNhan);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteBillByFormID(int formID)
        {
            string query = "DELETE FROM HOADON WHERE MaPhieu = @formID";
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@formID", formID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public bool IsMaPhieuExists(int maPhieu)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM HOADON WHERE MaPhieu = @MaPhieu";

            SqlConnection connection = SqlConnectionData.Connect();


            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);

                connection.Open();
                exists = (int)command.ExecuteScalar() > 0;
            }

            return exists;
        }


        public BillDTO getBillByFormID(int recruitFormID)
        {
            var sql1 = "select MaHoaDon, MaThue, SoTien, DaNhan from HOADON where MaPhieu = @formID";
            SqlConnection connection = SqlConnectionData.Connect();
            connection.Open();
            var command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@formID", recruitFormID);
            command1.ExecuteNonQuery();
            var reader1 = command1.ExecuteReader();
            var bill = new BillDTO();
            while (reader1.Read())
            {
                bill.MaHoaDon = (int)reader1["MaHoaDon"];
                bill.MaThue = (string)reader1["MaThue"];
                bill.SoTien = (int)reader1["SoTien"];
                bill.DaNhan = (int)reader1["DaNhan"];
                bill.MaPhieu = recruitFormID;
            }

            return bill;
        }

    }
}
