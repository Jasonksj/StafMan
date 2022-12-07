using Staff_Management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management
{
    public partial class Splash_Screen : Form
    {
        public Splash_Screen()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void label_status_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;

            //label_status.Text = "Tentative de connexion a la base de donnée ...";
            //label_status.Refresh();
            ////code
            //Thread.Sleep(3000);
            //progressBar1.Value = 30;
            //progressBar1.Refresh();

            //label_status.Text = "Vérification du compte par défaut ...";
            //label_status.Refresh();
            ////code
            //Thread.Sleep(1000);
            //progressBar1.Value += 10;
            //progressBar1.Refresh();

            //label_status.Text = "Recupération des données distantes ...";
            //label_status.Refresh();
            ////code
            //Thread.Sleep(1000);
            //progressBar1.Value += 50;
            //progressBar1.Refresh();

            //label_status.Text = "Ouverture de l'application...";
            //label_status.Refresh();
            ////code

            //Frmlogin login = new Frmlogin();
            //login.Hide();
            //Thread.Sleep(1000);
            //progressBar1.Value += 10;
            //progressBar1.Refresh();

            //login.Show();
            //this.Close();

        }

    
    }
}
