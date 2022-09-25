using static System.Console;
using DAL;
namespace GUI
{
    public class Login
    {
        private string user = "";
        private string pass = "";
        public string payload()
        {
            Clear();
            Write("\nNhập tên đăng nhập: ");
            this.user = ReadLine() ?? "";
            Write("\nNhập mật khẩu: ");
            this.pass = ReadLine() ?? "";
            CheckUser check = new CheckUser();
            string state = check.CheckUsers(this.user.Trim(), this.pass.Trim());
            if (state != null && state != "") {
                return state;
            }
            else {
                return "";
            }
        }

        public string[] ReturnAccount() {
            string[] account = {this.user, this.pass};
            return account;
        }
    }
}