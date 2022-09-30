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
            query = @"SELECT * FROM motel_managment.people where room_id = @room_id;";
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
        
        public bool AddPerson(string person_id, string name, string address, string phone, string username, string password, string room_id) {
            connection.Open();
            query = $"INSERT INTO `motel_managment`.`people` (`person_id`, `person_name`, `person_address`, `person_phone_number`, `username`, `password`, `describe`, `room_id`) VALUES ({person_id}, {name}, {address}, {phone}, {username}, {password}, 'custom', {room_id})";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteReader();
            connection.Close();
            return true;
        }
        public string MaxId()
        {
            connection.Open();
            query = "select max(person_id) as id from motel_managment.people;";
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
            query = @"delete from people where person_id = @id";
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
            person.EmpNo = reader.GetString("person_id");
            person.Name = reader.GetString("person_name");
            person.Address = reader.GetString("person_address");
            person.PhoneNumber = reader.GetString("person_phone_number");
            person.username = reader.GetString("username");
            person.password = reader.GetString("password");
            person.describe = reader.GetString("describe");
            person.rom_id = reader.GetString("room_id");
            return person;
        }
    } 
}

