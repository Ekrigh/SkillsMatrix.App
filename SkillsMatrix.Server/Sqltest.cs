using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace SkillsMatrix.Server
{
    class Sqltest
    {
        public static void Main()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=skillsmatrixdb;Uid=root;Pwd=root;";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Debug.WriteLine("Connection to MySQL database successful!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
