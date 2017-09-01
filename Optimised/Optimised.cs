using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimised
{
    public partial class Optimised : Form
    {
          string Parola;
          string Username;
          string Email;
            string token;
        public Optimised()
        {
            InitializeComponent();
            if(Program.tokens!=string.Empty)
            {
                token = Program.tokens;
            }
            else
            {
                token = Login.token;
            }
            if (Program.Email_Autologin != string.Empty && Program.Parola_Autologin != string.Empty && Program.User_Autologin != string.Empty)
            {
                Parola = Program.Parola_Autologin;
                Username = Program.User_Autologin;
                Email = Program.Email_Autologin;
            }
            else
            {
            Parola = Login.Parola_Login;
            Username = Login.User_Login;
            Email = Login.Email_Login;
            }
            Console.WriteLine(token);
            Console.WriteLine(Parola);
            Console.WriteLine(Username);
            Console.WriteLine(Email);
        }
    }
}
