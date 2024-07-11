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
    internal class RecruitmentBUS
    {

        private RecruitFormDAO _recruitFormDAO;


        public RecruitmentBUS()
        {
            _recruitFormDAO = new RecruitFormDAO();
        }


        public BindingList<RecruitmentDTO> getAllRecruitment()
        {
            return _recruitFormDAO.getAllRecruitment();
        }

        public void updateRecruitStatus(RecruitmentDTO recruitment)
        {
            _recruitFormDAO.updateRecruitStatus(recruitment);
        }

        public void setValidity(RecruitmentDTO recruitment, bool isValidity)
        {
            if (isValidity)
            {
                recruitment.Validity = "OK";
            }
            else
            {
                recruitment.Validity = "NOT OK";
            }
        }

        public void deleteRecruit(RecruitmentDTO recruitment)
        {
            _recruitFormDAO.deleteRecruit(recruitment);
        }


        public int getAdvertiseByRecruitFormID(int recruitFormID)
        {
            return _recruitFormDAO.getAdvertiseByRecruitFormID(recruitFormID);
        }


    }
}
