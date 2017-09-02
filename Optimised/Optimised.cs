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
        #region Variabile_Globale
            //Variabile Globale Start
            string Parola; //Aici se salveaza Parola.
            string Username; //Aici se salveaza Utilizatorul.
            string Email; //Aici se salveaza Emailul.
            string token; //Aici se salveaza token-ul.
            //Variabile Globale End
            #endregion
        #region Initializare_App
                public Optimised()
                {
                    InitializeComponent();
                    if(Program.tokens!=string.Empty) //Se verifica daca token-ul trimis din AutoLogin este null.
                    {
                        token = Program.tokens; //Se seteaza token-ul trimis din AutoLogin.
                    }
                    else //Daca nu sa folosit AutoLogin trece aici.
                    {
                        token = Login.token; //Se seteaza token-ul trimis din Login.
                    }
                    if (Program.Email_Autologin != string.Empty && Program.Parola_Autologin != string.Empty && Program.User_Autologin != string.Empty) //Daca datele trimise din AutoLogin nu sunt nule sare aici.
                    {
                        //Seteaza datele primite din AutoLogin.
                        Parola = Program.Parola_Autologin; 
                        Username = Program.User_Autologin;
                        Email = Program.Email_Autologin;
                        //Seteaza datele primite din AutoLogin.
                    }
                    else //Daca nu sa folosit AutoLogin sare aici.
                    {
                        //Seteaza datele primite din Login.
                        Parola = Login.Parola_Login;
                        Username = Login.User_Login;
                        Email = Login.Email_Login;
                        //Seteaza datele primite din Login.
                    }
                }
        #endregion
        #region Logout
        private void Optimised_FormClosing(object sender, FormClosingEventArgs e)
        {
            string logout = Functii.DownloadString("http://optimised.biz/logoutapp/" + Username + "/" + Email + "/" + Parola +"/" +token); //Cere informatii despre Login la API.
        }
#endregion
    }
}
