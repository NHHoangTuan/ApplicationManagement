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
    internal class CandidateBUS
    {

        private CandidateDAO _candidateDAO;


        public CandidateBUS()
        {
            _candidateDAO = new CandidateDAO();
        }


        public BindingList<CandidateDTO> getAllCandidate()
        {

            BindingList<CandidateDTO> list = new BindingList<CandidateDTO>(_candidateDAO.GetCandidates());

            return list;
        }

        public void saveCandidate(CandidateDTO candidate)
        {
            _candidateDAO.SaveCandidate(candidate);
        }

        public CandidateDTO getCandidateByID(string id)
        {
            return _candidateDAO.getCandidateByID(id);
        }

    }
}
