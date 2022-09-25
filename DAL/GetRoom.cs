using MySql.Data.MySqlClient;
using Obj_Item;

namespace DAL
{
    public class GetRoomDB
    {
        private static MySqlConnection connection = DBconfig.GetConnection();
        private string? query;
        public List<Room> GetAllRoom()
        {
            List<Room> list_room = new List<Room>();
            connection.Open();
            query = @"select * from room";
            MySqlCommand command = new MySqlCommand(query, connection);
            using var result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    list_room.Add(new Room(result.GetString("rom_id"), result.GetString("start_date"), result.GetString("end_date"), result.GetDouble("e_price"), result.GetDouble("w_price"), result.GetDouble("s_price"), result.GetDouble("r_price"), result.GetString("status")));
                }
            }
            connection.Close();
            return list_room;
        }
        public Room? GetRoomById(string id)
        {
            connection.Open();
            query = @"select * from room where rom_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add(new MySqlParameter("@id", id));
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                Room room = new Room();
                while (reader.Read())
                {
                    room.room_id = reader.GetString("rom_id");
                    room.start_date = reader.GetString("start_date");
                    room.end_date = reader.GetString("end_date");
                    room.electricity_price = reader.GetDouble("e_price");
                    room.water_price = reader.GetDouble("w_price");
                    room.service_price = reader.GetDouble("s_price");
                    room.status = reader.GetString("status");
                    room.room_price = reader.GetDouble("r_price");
                }
                reader.Close();
                return room;
            }
            catch (System.Exception)
            {

                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public void AddRoom(string id, string start_date, string end_date, double room_price, double e_price, double w_price, double s_price, string status)
        {
            connection.Open();
            query = @"INSERT INTO `motel_managment`.`room` (`rom_id`, `start_date`, `end_date`, `e_price`, `w_price`, `s_price`, `status`, `r_price`) VALUES (@id, @s_date, @e_date, @e_price, @w_price, @s_price, @status, @r_price)"; MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add(new MySqlParameter("@id", id));
            command.Parameters.Add(new MySqlParameter("@s_date", start_date));
            command.Parameters.Add(new MySqlParameter("@e_date", end_date));
            command.Parameters.Add(new MySqlParameter("@e_price", e_price));
            command.Parameters.Add(new MySqlParameter("@w_price", w_price));
            command.Parameters.Add(new MySqlParameter("@s_price", s_price));
            command.Parameters.Add(new MySqlParameter("@status", status));
            command.Parameters.Add(new MySqlParameter("@r_price", room_price));
            command.ExecuteReader();
            connection.Close();
        }
        public string MaxId()
        {
            connection.Open();
            query = "select max(rom_id) as id from motel_managment.room;";
            MySqlCommand command = new MySqlCommand(query, connection);
            string id = "0";
            try
            {
                MySqlDataReader result = command.ExecuteReader();
                if (result.Read())
                {
                    id = result.GetString("id");
                }
                return id;
            }
            catch {
                return "0";
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteRoom(string id)
        {
            connection.Open();
            query = @"delete from room where rom_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("id", MySqlDbType.VarChar).Value = id;
            try
            {
                command.ExecuteReader();
                return true;
            }
            catch
            {
                Console.WriteLine("Phòng không tồn tại");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
