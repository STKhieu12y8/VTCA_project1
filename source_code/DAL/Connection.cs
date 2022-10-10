using MySql.Data.MySqlClient;


namespace DAL {
    public class DBconfig {
        public static MySqlConnection connection = new MySqlConnection();
        public static MySqlConnection GetConnection() {
            string connectionString = "server=localhost;user id = root; password = 123456789; port = 3306; database= motel_managment";
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
} 