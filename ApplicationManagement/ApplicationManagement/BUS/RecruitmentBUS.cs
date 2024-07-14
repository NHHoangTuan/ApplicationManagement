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

        public void setValidity(RecruitmentDTO recruitment, string Validity)
        {
            if (Validity == "OK")
            {
                recruitment.Validity = "OK";
            }
            else if(Validity == "REJECT")
            {
                recruitment.Validity = "REJECT";
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



        public BindingList<RecruitmentDTO> getAllRecruitmentWaitingPayment(string TaxID)
        {
            return _recruitFormDAO.getAllRecruitmentWaitingPayment(TaxID);
        }

        public BindingList<RecruitmentDTO> getAllRecruitmentWaitingPost()
        {
            return _recruitFormDAO.getAllRecruitmentWaitingPost();
        }

        public BindingList<RecruitmentDTO> getAllRecruitmentForApplication()
        {
            return _recruitFormDAO.getAllRecruitmentForApplication();
        }


        public void updateValidity(int maPhieuTD, string validity)
        {
            _recruitFormDAO.updateValidity(maPhieuTD, validity);
        }

        public BindingList<RecruitmentDTO> getAllRecruitmentForEnterprise(string enterpriseID)
        {
            return _recruitFormDAO.getAllRecruitmentForEnterprise(enterpriseID);
        }
    }
}
