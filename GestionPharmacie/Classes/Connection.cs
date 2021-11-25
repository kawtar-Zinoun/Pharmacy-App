using MySql.Data.MySqlClient;
using System;

namespace GestionPharmacie.Classes
{
    class Connection
    {
        public MySqlConnection conn = null;
        public void ToConnect()
        {
            string cs = @"server=localhost;userid=root;
            password=root;database=pharmacie";

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Write("Connection error, {0}", ex.Message);

            }
        }
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;
        }
    }
}
