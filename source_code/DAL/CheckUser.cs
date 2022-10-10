using static System.Console;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class CheckUser
    {
        private MySqlConnection connection = DBconfig.GetConnection();
        public string CheckUsers(string username, string password)
        {
            connection.Open();
            string query = @"select * from people where username = @user and password = @pass";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add(new MySqlParameter("@user", username));
            command.Parameters.Add(new MySqlParameter("@pass", password));
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    return reader.GetString("describe");
                }
                else
                {
                    return "null";
                }

            }
            catch (System.Exception e)
            {
                WriteLine(e);
                return "";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
