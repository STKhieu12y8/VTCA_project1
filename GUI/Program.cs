using static System.Console;
using System.Text;
using GUI;
using Obj_Item;

public class Program
{
    static void Main(string[] args)
    {
        OutputEncoding = Encoding.UTF8;
        InputEncoding = Encoding.UTF8;
        Clear();
        Menu_Item menu = new Menu_Item();
        string title = "Nhà Trọ The Scammer";
        string[] list_item = { "Đăng Nhập", "Tắt chương trình" };
        for (int i = 0; i < 3;)
        {
            int choose = menu.Menu(title, list_item);
            switch (choose)
            {
                case 1:
                    Login log = new Login();
                    string result = log.payload();
                    if (result == "admin")
                    {
                        Admin admin = new Admin();
                        Clear();
                        admin.GuiDisplay();
                    }
                    else if (result == "custom")
                    {
                        Customer customer = new Customer();
                        string[] account = log.ReturnAccount();
                        Clear();
                        customer.GuiDisplay(account);
                    }
                    else
                    {
                        WriteLine("\nTài khoản không tồn tại !");
                        System.Threading.Thread.Sleep(3000);
                        Clear();
                        i++;
                    }
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Nhập không hợp lệ");
                    break;
            }
        }
    }
}