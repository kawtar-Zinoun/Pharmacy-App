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
        
        public bool ToLogin(String email, String password)
        {
             if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                c1.ToConnect();
                string query = "select id_user,user_name,user_email,user_password from users WHERE user_email ='" + email + "' AND user_password ='" + password + "'";
                MySqlDataReader row;
                row = c1.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        String id = row["id_user"].ToString();
                        String username = row["use_rname"].ToString();
                        String pass_word = row["user_password"].ToString();
                        String useremail = row["user_email"].ToString();
                    }
                    return true,
                   // MessageBox.Show("Data found your name is " + username + " " + lastname + " " + " and your address at " + address);
                }
                else
                {
                    return false;
                  //  MessageBox.Show("Data not found", "Information");
                }
            }
             else
            {
                return false; // email or password are null
            }
        }
    }
}
