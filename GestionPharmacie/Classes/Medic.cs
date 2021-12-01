using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPharmacie.Classes
{
    class Medic
    {
        readonly Connection c1 = new Connection();

        public bool UpdateMedic(string column, string medicId, string newValue) // To update a medic in database
        {
            try {
                c1.ToConnect();
                string Query = "update medic set " + column + " = '" + newValue + "' where medic_id = " + medicId + ";";
                MySqlCommand MyCommand = new MySqlCommand(Query, c1.conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            }

    }
}
