using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.BUS
{
    internal class BillBUS
    {
        private BillDAO billDAO;

        public BillBUS()
        {
            billDAO = new BillDAO();
        }

        public int CreateBill(BillDTO bill)
        {
            return billDAO.AddBill(bill);
        }

        public BindingList<BillDTO> GetAllBills()
        {
            return billDAO.GetAllBills();
        }

        public void setDaNhan(BillDTO bill, int valid)
        {
            if (valid == 1)
            {
                bill.DaNhan = 1;
            }
            else
            {
                bill.DaNhan = 0;
            }
        }

        public void updateDaNhan(BillDTO bill)
        {
            billDAO.updateDaNhan(bill);
        }


        public bool IsMaPhieuExists(int maPhieu)
        {
            return billDAO.IsMaPhieuExists(maPhieu);
        }

        public BillDTO getBillByFormID(int recruitFormID)
        {
            return billDAO.getBillByFormID(recruitFormID);
        }
    }
}
