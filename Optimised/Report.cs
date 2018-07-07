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
    public partial class Report : Form
    {
        string Token;
        string Key;
        string Id;
        string Email;
        public Report(string token,string key,string id,string email)
        {
            InitializeComponent();
            Token = token;
            Key = key;
            Id = id;
            Email = email;
        }

        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            if(mesaj.Text!=string.Empty && nume.Text!=string.Empty)
            {
                Functii.DownloadString("http://" + Functii.webip + "/report/" + Key + "/" + Token + "/"+ Id +"/"+ Email+"/"+nume.Text+"/"+mesaj.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ambele campuri sunt necesare.");
            }
        }
    }
}
