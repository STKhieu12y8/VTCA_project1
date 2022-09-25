using Obj_Item;
using MySql.Data.MySqlClient;

namespace DAL
{
   public class GetPersonDB
    {
        private static MySqlConnection connection = DBconfig.GetConnection();
        private string? query;

        public Person GetPersonByAccount(string username, string password)
        {
            Person person = new Person();
            connection.Open();
            query = @"SELECT * FROM motel_managment.people where username = @username and password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add((new MySqlParameter("@username", username)));
            command.Parameters.Add((new MySqlParameter("@password", password)));
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                person = GetPerson(reader);
            }
            else
            {
                person = (new Person());
            }
            connection.Close();
            return person;

        }
        public List<Person> GetAllPeopleInRoom(string room_id) {
            List<Person> list_people_in_room = new List<Person>();
            connection.Open();
            query = @"SELECT * FROM motel_managment.people where rom_id = @room_id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@room_id", MySqlDbType.VarChar).Value = room_id;
            using var result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    list_people_in_room.Add(GetPerson(result));
                }
            }
            connection.Close();
            return list_people_in_room;
        }

        public List<Person> GetAllPeople() {
            List<Person> list_people_in_room = new List<Person>();
            connection.Open();
            query = @"SELECT * FROM motel_managment.people";
            MySqlCommand command = new MySqlCommand(query, connection);
            using var result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    list_people_in_room.Add(GetPerson(result));
                }
            }
            connection.Close();
            return list_people_in_room;
        }
        
        public bool AddPerson(string admin_id, string name, string address, string phone, string username, string password, string room_id) {
            connection.Open();
            query = $"INSERT INTO `motel_managment`.`people` (`admin_id`, `admin_name`, `admin_address`, `admin_phone_number`, `username`, `password`, `describe`, `rom_id`) VALUES ({admin_id}, {name}, {address}, {phone}, {username}, {password}, 'custom', {room_id})";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteReader();
            connection.Close();
            return true;
        }
        public string MaxId()
        {
            connection.Open();
            query = "select max(admin_id) as id from motel_managment.people;";
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

        public bool DeletePerson(string id)
        {
            connection.Open();
            query = @"delete from people where admin_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("id", MySqlDbType.VarChar).Value = id;
            try
            {
                command.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        internal Person GetPerson(MySqlDataReader reader)
        {
            Person person = new Person();
            person.EmpNo = reader.GetString("admin_id");
            person.Name = reader.GetString("admin_name");
            person.Address = reader.GetString("admin_address");
            person.PhoneNumber = reader.GetString("admin_phone_number");
            person.username = reader.GetString("username");
            person.password = reader.GetString("password");
            person.describe = reader.GetString("describe");
            person.rom_id = reader.GetString("rom_id");
            return person;
        }
    } 
}

