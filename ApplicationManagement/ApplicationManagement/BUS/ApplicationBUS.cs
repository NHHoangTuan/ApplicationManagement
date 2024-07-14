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
    internal class ApplicationBUS
    {

        private ApplicationDAO applicationDAO;

        public ApplicationBUS()
        {
            applicationDAO = new ApplicationDAO();
        }

        public int addApplication(ApplicationDTO applicationDTO)
        {
            int applicationID = applicationDAO.insertApplication(applicationDTO);

            return applicationID;
        }


        public BindingList<ApplicationDTO> getAllApplication()
        {
            return applicationDAO.getAllApplication();
        }

        public BindingList<ApplicationDTO> getAllApplicationForCandidate(string candidateID)
        {
            return applicationDAO.getAllApplicationForCandidate(candidateID);
        }

        public void updateApplicationStatus(ApplicationDTO application)
        {
            applicationDAO.updateApplicationStatus(application);
        }

        public void deleteApplication(ApplicationDTO r)
        {
            applicationDAO.deleteApplication(r);
        }

        public void setValidity(ApplicationDTO application, string Validity)
        {
            if (Validity == "OK")
            {
                application.Validity = "OK";
            }
            else if(Validity == "REJECT")
            {
                application.Validity = "REJECT";
            }
            else
            {
                application.Validity = "NOT OK";
            }
        }


        public BindingList<ApplicationDTO> getAllApplicationByEnterprise(string maThue)
        {
            return applicationDAO.getAllApplicationByEnterprise(maThue);
        }

        public BindingList<ApplicationDTO> getAllResultForCandidate(string userID)
        {
            return applicationDAO.getAllResultForCandidate(userID);
        }

        public void updateCVPath(int maPhieu, string cvPath)
        {
            applicationDAO.updateCVPath(maPhieu, cvPath);
        }
    }
}
