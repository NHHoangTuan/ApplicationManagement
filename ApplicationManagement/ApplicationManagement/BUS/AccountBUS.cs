﻿using ApplicationManagement.DAO;
using ApplicationManagement.DTO;

namespace ApplicationManagement.BUS {
    internal class AccountBUS {
        AccountAccess accountAccess = new AccountAccess();

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
    }
}