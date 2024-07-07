using ApplicationManagement.DTO;

namespace ApplicationManagement.DAO {
    internal class AccountAccess : DatabaseHelper {
        public string CheckLogin(Account account) {
            string info = CheckLoginDTO(account);
            return info;
        }
    }
}
