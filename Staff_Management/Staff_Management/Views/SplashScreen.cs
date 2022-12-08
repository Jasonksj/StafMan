using Staff_Management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            progressBar1.Value = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                label1.Text = "Tentative de connexion a la base de donnée ...";
                label1.Refresh();
                //code
                Thread.Sleep(3000);
                progressBar1.Value = 30;
                progressBar1.Refresh();

                label1.Text = "Vérification du compte par défaut ...";
                label1.Refresh();
                //code
                Thread.Sleep(1000);
                progressBar1.Value += 10;
                progressBar1.Refresh();

                label1.Text = "Recupération des données distantes ...";
                label1.Refresh();
                //code
                Thread.Sleep(1000);
                progressBar1.Value += 50;
                progressBar1.Refresh();

                label1.Text = "Ouverture de l'application...";
                label1.Refresh();
                Thread.Sleep(2000);
                Frmlogin frmlogin = new Frmlogin();
                frmlogin.Show();
                this.Hide();
            }
            label3.Text = progressBar1.Value.ToString() + "%";
        }
    }
}
