using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPharmacie.Classes
{
    class Login
    {
        Connection c1 = new Connection();
 
        public Object ToLogin(String email, String password)
        {
            String id = null, username =null, useremail = null;

            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
             {
                c1.ToConnect();
                string query = "select id_user,user_name,user_email,user_password from users WHERE user_email ='" + email + "' AND user_password ='" + password + "'";
                MySqlDataReader row;
                row = c1.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        id = row["id_user"].ToString();
                        username = row["user_name"].ToString();
                        useremail = row["user_email"].ToString();
                    }

                    var user = new { id, username, useremail }; // anonymous object to return later
                    return user;
                }
                else
                {
                  //  var user = new { id, username, useremail }; // anonymous empty object to return later
                    return null;
                }
            }
             else
            {
               // var user = new { id, username, useremail }; // anonymous empty object to return later
                return null;
            }
        }
    }
}
