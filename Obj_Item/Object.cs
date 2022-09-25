using static System.Console;

namespace Obj_Item
{
    public class Person
    {
        public string EmpNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? describe { get; set; }
        public string rom_id { get; set; }
        public Person(string id, string name, string address, string phone, string username, string password, string rom_id)
        {
            this.EmpNo = id;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phone;
            this.username = username;
            this.password = password;
            this.rom_id = rom_id;
        }
        public Person()
        {
            this.EmpNo = "null";
            this.Name = "null";
            this.Address = "null";
            this.PhoneNumber = "null";
            this.username = "null";
            this.password = "null";
            this.rom_id = "null";
        }
        public void ShowI4()
        {
            WriteLine($"\tTên: {this.Name, -18}  Địa chỉ: {this.Address, -20} Số điện thoại: {this.PhoneNumber, -14} Phòng thuê: {this.rom_id, -5} Mã khách hàng: {this.EmpNo}");
        }
    }

    public class Menu_Item
    {
        public int Menu(string title, string[] menuItem)
        {
            int choice = 0;
            string line = "==============================================================";
            WriteLine($"\n\t{title}\n");
            for (int i = 0; i < menuItem.Length; i++)
            {
                WriteLine("{0,-2}. {1 , -20}", i + 1, menuItem[i]);
            }
            WriteLine(line);
            do
            {
                Write("Lựa chọn: ");
                try
                {
                    choice = Int16.Parse(ReadLine() ?? "");
                }
                catch
                {
                    WriteLine("Bạn chọn không hợp lệ !");
                }
            }
            while (choice <= 0 || choice > menuItem.Length);
            return choice;
        }
    }

    public class Room
    {
        public string room_id { get; set; }
        public string? start_date { get; set; }
        public string? end_date { set; get; }
        public double electricity_price { set; get; }
        public double water_price { set; get; }
        public double room_price { set; get; }
        public double service_price { set; get; }
        public string status { set; get; }

        public Room()
        {
            electricity_price = 3.5;
            water_price = 30;
            room_price = 3000;
            service_price = 200;
            status = "null";
            room_id = "";
        }

        public Room(string rom_id, string start_date, string end_date, double electricity_price, double w_price, double s_price, double r_price, string status)
        {
            this.room_id = rom_id;
            this.start_date = start_date;
            this.end_date = end_date;
            this.electricity_price = electricity_price;
            this.water_price = w_price;
            this.service_price = s_price;
            this.room_price = r_price;
            //this.status = status;
            if (status == "used")
            {
                this.status = "Đã Thuê";
            }
            else
            {
                this.status = "Còn trống";
            }
        }
        public double[] GetBill()
        {
            Random random = new Random();
            double[] result = { 1700, 300 };
            result[0] = this.room_price + this.service_price * 3;
            result[1] = this.electricity_price * Math.Floor(random.NextDouble() * 100) + this.water_price * Math.Floor(random.NextDouble() * 10);
            return result;
        }
        public void Short_DL()
        {
            WriteLine("Phòng: " + this.room_id + " Trạng thái: " + this.status + "\n");
        }
        public void Show_Room()
        {
            WriteLine("\n----------------------------------------------");
            WriteLine("Phòng: " + this.room_id);
            WriteLine("\nGiá điện: {0, -4}k/số    Giá nước: {1, -4}k/khối    Giá dịch vụ: {2, -8}    Giá phòng: {3}k/phòng", this.electricity_price, this.water_price, this.service_price, this.room_price);
            WriteLine("\nTình trạng phòng: đã thuê");
            WriteLine("\nNgày thuê: {0, -15} Ngày kết thúc: {1}", this.start_date, this.end_date);
            WriteLine("\nTổng tiền: " + (GetBill()[0]+ GetBill()[1]) + "K\n");
        }

    }

}