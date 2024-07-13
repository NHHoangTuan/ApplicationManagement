using ApplicationManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.BUS
{
    class ApproveBUS
    {

        private ApproveDAO approveDAO;

        public ApproveBUS()
        {
            approveDAO = new ApproveDAO();
        }


        public void insertApprove(int MaPhieuUT, string MaThue)
        {
            approveDAO.insertApprove(MaPhieuUT, MaThue);
        }

        public void updateApproveStatus(int MaPhieuUT, int status)
        {
            approveDAO.updateApproveStatus(MaPhieuUT, status);
        }


    }
}
