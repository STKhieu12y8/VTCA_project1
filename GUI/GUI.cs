using static System.Console;
using DAL;
using Obj_Item;

namespace GUI
{
    public class Admin
    {
        public void GuiDisplay()
        {
            while (true)
            {
                Clear();
                bool check = false;
                Menu_Item menu_Item = new Menu_Item();
                string[] list = { "Quản lý phòng", "Quản lý người thuê", "Đăng xuất" };
                int choice = menu_Item.Menu("Bạn đang đăng nhập với quyền admin", list);
                WriteLine();
                GetRoomDB roomDB = new GetRoomDB();
                GetPersonDB personDB = new GetPersonDB();
                switch (choice)
                {
                    case 1:
                        Clear();
                        foreach (var i in roomDB.GetAllRoom())
                        {
                            i.Short_DL();
                        }
                        string[] s_list = { "Vào phòng", "Thêm phòng", "Trở về màn hình trước" };
                        int s_choice = menu_Item.Menu("", s_list);

                        if (s_choice == 1)
                        {
                            Clear();
                            foreach (var i in roomDB.GetAllRoom())
                            {
                                i.Short_DL();
                            }
                            //Lay ra 1 phong can xem
                            Write("Nhập phòng: ");
                            string id = ReadLine() ?? "";
                            Room? room = roomDB.GetRoomById(id.ToString());
                            if (room == null)
                            {
                                WriteLine("Phòng không tồn tại");
                            }
                            else
                            {
                                room.Show_Room();
                                string[] m_list = { "Xem người trong phòng", "Trở về màn hình trước" };
                                int m_choice = menu_Item.Menu("", m_list);
                                switch (m_choice)
                                {
                                    case 1:
                                        //lay ra tat ca nguoi trong phong
                                        Clear();
                                        foreach (var item in personDB.GetAllPeopleInRoom(id))
                                        {
                                            item.ShowI4();
                                        }
                                        string[] n_list = { "Xóa người", "Trở về màn hình trước" };
                                        int n_choice = menu_Item.Menu("", n_list);
                                        switch (n_choice)
                                        {
                                            case 1:
                                                // Xoa nguoi
                                                Write("Nhập id người cần xóa: ");
                                                string p_id = ReadLine() ?? "";
                                                bool s_check = personDB.DeletePerson(p_id);
                                                if (s_check)
                                                {
                                                    WriteLine("Xóa thành công");
                                                }
                                                else
                                                {
                                                    WriteLine("Xóa thất bại");
                                                }
                                                Clear();
                                                break;
                                            default:
                                                Clear();
                                                break;
                                        }
                                        break;
                                    case 2:
                                        Clear();
                                        break;
                                    default:
                                        WriteLine("Lựa chọn không hợp lệ");
                                        break;
                                }

                            }
                        }
                        else if (s_choice == 2)
                        {
                            WriteLine("Tạo phòng mới");
                            int id = int.Parse(roomDB.MaxId()) + 1;
                            WriteLine("Số phòng mới: " + id);
                            Write("Ngày thuê: ");
                            string s_date = ReadLine() ?? "";
                            Write("Ngày kết thúc: ");
                            string e_date = ReadLine() ?? "";
                            Write("Giá phòng: ");
                            double r_price = double.Parse(ReadLine() ?? "");
                            Write("Giá điện: ");
                            double e_price = double.Parse(ReadLine() ?? "");
                            Write("Giá nước: ");
                            double w_price = double.Parse(ReadLine() ?? "");
                            Write("Giá dịch vụ: ");
                            double s_price = double.Parse(ReadLine() ?? "");
                            Write("Trạng thái: ");
                            string status = ReadLine() ?? "";
                            roomDB.AddRoom(id.ToString(), s_date, e_date, r_price, e_price, w_price, s_price, status);
                            WriteLine("Thêm phòng thành công");
                        }
                        else
                        {
                            WriteLine("Bạn chọn không hợp lệ !");
                        }
                        break;
                    case 2:
                        string title = "";
                        string[] a_list = { "Thêm khách hàng", "Xóa khách hàng", "Trở về màn hình trước" };
                        bool exit = false;
                        while (true)
                        {
                            Clear();
                            WriteLine("Bạn đang đăng nhập với quyền admin\n");
                            WriteLine("Danh sách khách hàng thuê:\n");
                            foreach (Person item in personDB.GetAllPeople())
                            {
                                item.ShowI4();
                            }
                            int a_choice = menu_Item.Menu(title, a_list);
                            switch (a_choice)
                            {
                                case 1:
                                    Clear();
                                    int ad_id = int.Parse(personDB.MaxId()) + 1;
                                    WriteLine("Mã khách hàng tự động tạo: " + ad_id);
                                    Write("Nhập tên khách hàng: ");
                                    string name = ReadLine() ?? "";
                                    Write("Nhập số điện thoại khách hàng: ");
                                    string phone = ReadLine() ?? "";
                                    Write("Nhập địa chỉ nơi ở khách hàng: ");
                                    string address = ReadLine() ?? "";
                                    Write("Nhập tên tài khoản đăng nhập cho khách hàng: ");
                                    string user = ReadLine() ?? "";
                                    Write("Nhập mật khẩu đăng nhập cho khách hàng: ");
                                    string pass = ReadLine() ?? "";
                                    Write("Nhập mã phòng ở cho khách: ");
                                    string rom_id = ReadLine() ?? "";
                                    bool add_check = personDB.AddPerson(ad_id.ToString(), name, address, phone, user, pass, rom_id);
                                    if (add_check)
                                    {
                                        WriteLine("Thêm thành công");
                                    }
                                    else
                                    {
                                        WriteLine("Thêm thất bại");
                                    }
                                    break;
                                case 2:
                                    Write("Nhập mã khách hàng cần xóa: ");
                                    string a_id = ReadLine() ?? "";
                                    bool a_check = personDB.DeletePerson(a_id);
                                    if (a_check)
                                    {
                                        WriteLine("Xóa thành công");
                                    }
                                    else
                                    {
                                        WriteLine("Xoá thất bại");
                                    }
                                    break;
                                case 3:
                                    exit = true;
                                    Clear();
                                    break;
                                default:
                                    WriteLine("Nhập không hợp lệ");
                                    break;
                            }
                            if (exit)
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        check = true;
                        break;
                    default:
                        WriteLine("Nhập không hợp lệ");
                        break;
                }
                if (check == true)
                {
                    break;
                }
            }
        }
    }
    public class Customer
    {
        public void GuiDisplay(string[] account)
        {
            Clear();
            GetPersonDB getPersonDB = new GetPersonDB();
            GetRoomDB getRoomDB = new GetRoomDB();
            Menu_Item menu_Item = new Menu_Item();
            Person person = getPersonDB.GetPersonByAccount(account[0], account[1]);
            Room? room = getRoomDB.GetRoomById(person.rom_id);

            string[] list = { "Đăng Xuất", "Thoát" };
            if (room == null)
            {
                room = new Room();
            }

            WriteLine("=======================================================\n");
            WriteLine("      Bạn đã đăng nhập với tên " + person.Name + "\n");
            WriteLine("      Bạn đang ở phòng số {0}\n", person.rom_id);
            WriteLine("      Ngày thuê: {0} Ngày kết thúc: {1}\n", room.start_date, room.end_date);
            WriteLine($"      Giá phòng: {room.room_price}VNĐ\tGiá điện: {room.electricity_price}VNĐ\tGiá nước: {room.water_price}VNĐ\tGiá dịch vụ: {room.service_price}VNĐ\n");
            WriteLine("      Thánh toán 3 tháng tiền nhà và dịch vụ 1 lần, tiền điện nước thanh toán cuối tháng\n");
            WriteLine($"      Số điện đã sử dụng: {room.GetBill()[0]}\t\tSố nước đã sử dụng: {room.GetBill()[1]}\n");
            WriteLine("      Tổng tiền phải thanh toán: " + room.GetBill()[2] + " VNĐ\n");
            int choice = menu_Item.Menu("", list);
            switch (choice)
            {
                case 1:
                    Clear();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Nhập không hợp lệ thoát");
                    break;
            }
        }
    }
}