using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System.Data.SqlClient;
using System;

namespace ApplicationManagement.BUS {
    internal class AccountBUS {
        AccountAccess accountAccess;
        CandidateDAO _candidateDAO;
        AccountDAO _accountDAO;


        public AccountBUS()
        {
            accountAccess = new AccountAccess();
            _candidateDAO = new CandidateDAO();
            _accountDAO = new AccountDAO();
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

        public bool IsUsernameExist(string username)
        {
            return _accountDAO.IsUsernameExist(username);
        }


        public Account getAccountByUsername(string username)
        {
            return _accountDAO.getAccountByUsername(username);
        }
    }
}
