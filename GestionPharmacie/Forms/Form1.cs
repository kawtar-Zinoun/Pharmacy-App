using GestionPharmacie.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPharmacie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private String Email { get; set; }
        private String Password { get; set; }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
           String email = guna2TextBox1.Text;
       
            if (String.IsNullOrEmpty(email))
            {
                emailError.Text = "Please enter an email";
                guna2Button1.Enabled = false;

            }
            else
            {
                try
                {
                    var addr = new MailAddress(email);
                    if (addr.Address == email)
                    {
                        emailError.Text = "";
                        Email = email;
                        guna2Button1.Enabled = true;
                    }
                }
                catch
                {
                    emailError.Text = "Please enter a valid email";
                    guna2Button1.Enabled = false;

                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            String password = guna2TextBox2.Text;
            if (String.IsNullOrEmpty(password))
            {
                passwordError.Text = "Please enter a password";
                guna2Button1.Enabled = false;
            }
            else
            {
                passwordError.Text = "";
                Password = password;
                guna2Button1.Enabled = true;

            }

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
        public bool LogIn()
        {
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
            {
                Login l1 = new Login();
                Object user = l1.ToLogin(Email, Password);
                if (user != null)
                    return true;
            }
          
            return false;
        }
    }
}
