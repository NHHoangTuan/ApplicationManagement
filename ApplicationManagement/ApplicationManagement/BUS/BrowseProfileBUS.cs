using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.BUS
{
    internal class BrowseProfileBUS
    {

        private BrowseProfileDAO browseProfileDAO;

        public BrowseProfileBUS() {
        
            browseProfileDAO = new BrowseProfileDAO();
        
        }

        public void insertBrowseProfile(int maPhieuQC, int maPhieuUT, DateTime now)
        {
            browseProfileDAO.insertBrowseProfile(maPhieuQC, maPhieuUT, now);
        }


        public int getApplicationFormIDWithCurrentUser(int maPhieuDT, string cccd)
        {
            return browseProfileDAO.getApplicationFormIDWithCurrentUser(maPhieuDT, cccd);
        }

        public BrowseProfileDTO getBrowseProfileByFormID(int maPhieuUT)
        {
            return browseProfileDAO.getBrowseProfileByFormID(maPhieuUT);
        }

    }
}
