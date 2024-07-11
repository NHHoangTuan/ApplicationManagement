using ApplicationManagement.DAO;
using ApplicationManagement.DTO;

namespace ApplicationManagement.BUS {
    internal class AccountBUS {
        AccountAccess accountAccess;
        CandidateDAO _candidateDAO;


        public AccountBUS()
        {
            accountAccess = new AccountAccess();
            _candidateDAO = new CandidateDAO();
        }

        public string CheckLogin(Account account) {
            // Kiểm tra nghiệp vụ
            if (account.Username == "") {
                return "empty_username";
            }

            if (account.Passwords == "") {
                return "empty_password";
            }
            string info = accountAccess.CheckLogin(account);
            return info;
        }

        public void addAccount(string username, string password, CandidateDTO candidate)
        {
            _candidateDAO.AddCandidateAccount(username, password, candidate);
        }

    }
}
