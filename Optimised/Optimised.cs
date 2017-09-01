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
        public static string Parola = Login.Pass;
        public static string Username = Login.Usser;
        public static string Email = Login.Email;
        public static string token = Login.token;
        public Optimised()
        {
            InitializeComponent();
            var MyIni = new IniFile(Functii.path);
            var Pass = MyIni.Read("Password");
            var Usser = MyIni.Read("Username");
            var comp = MyIni.Read("Email");
            Console.WriteLine(token);
            Console.WriteLine(Pass);
            Console.WriteLine(Usser);
            Console.WriteLine(comp);
        }
    }
}
