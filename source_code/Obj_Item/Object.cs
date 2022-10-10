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
                this.status = "Đang sử dụng";
            }
            else
            {
                this.status = "Còn trống";
            }
        }
        public double[] GetBill()
        {
            Random random = new Random();
            double[] result = new double[3];

            if (this.status == "trong") {
                result[0] = 0;
                result[1] = 0;
                result[2] = 0;
                return result;
            }

            double number_electricity_used = Math.Floor(random.NextDouble()* 100);
            double number_water_used = Math.Floor(random.NextDouble()* 10);
            double total = this.room_price*3 + this.service_price*3 + this.electricity_price*number_electricity_used + this.water_price*number_water_used;
            result[0] = number_electricity_used;
            result[1] = number_water_used;
            result[2] = total;
            return result;
        }
        public void Short_DL()
        {
            WriteLine("Phòng: " + this.room_id + " Trạng thái: " + this.status + "\n");
        }
        public void Show_Room()
        {
            double[] used = new double[3]{GetBill()[0], GetBill()[1], GetBill()[2]};

            WriteLine("\n----------------------------------------------");
            WriteLine("Phòng: " + this.room_id);
            WriteLine($"\nGiá điện: {this.electricity_price} VNĐ/số    Giá nước: {this.water_price} VNĐ/khối    Giá dịch vụ: {this.service_price} VNĐ    Giá phòng: {this.room_price} VNĐ/phòng");
            WriteLine("\nNgày thuê: {0, -15} Ngày kết thúc: {1}", this.start_date, this.end_date);
            WriteLine($"\nSố điện và số nước sử dụng từ {this.start_date} đến {DateTime.Now.ToString("dd/MM/yyyy")}");
            WriteLine($"\nSố điện sử dụng: {GetBill()[0]}\t Số nước sử dụng: {GetBill()[1]}");
            WriteLine($"\nTiền điện: {used[0]*this.electricity_price} VND   Tiền nước: {used[1]*this.water_price} VND Tổng tiền: {used[2]} VNĐ");
        }

        public void Show_Room_Custom()
        {
            double[] used = new double[3]{GetBill()[0], GetBill()[1], GetBill()[2]};
            WriteLine($"\nGiá điện: {this.electricity_price} VNĐ/số    Giá nước: {this.water_price} VNĐ/khối    Giá dịch vụ: {this.service_price} VNĐ    Giá phòng: {this.room_price} VNĐ/phòng");
            WriteLine("\nNgày thuê: {0, -15} Ngày kết thúc: {1}", this.start_date, this.end_date);
            WriteLine($"\nSố điện và số nước sử dụng từ {this.start_date} đến {DateTime.Now.ToString("dd/MM/yyyy")}");
            WriteLine($"\nSố điện sử dụng: {GetBill()[0]}\t Số nước sử dụng: {GetBill()[1]}");
            WriteLine($"\nTiền điện: {used[0]*this.electricity_price} VND   Tiền nước: {used[1]*this.water_price} VND Tổng tiền: {used[2]} VNĐ");
        }

    }

}   