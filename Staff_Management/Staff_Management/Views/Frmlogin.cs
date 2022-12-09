using Staff_Management.Controllers;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Staff_Management.Views
{
    public partial class Frmlogin : Form
    {
        bool exitApp = true;
        UtilisateurControllers userControllers;
        Entities.Utilisateur user;
        public Frmlogin()
        {
            InitializeComponent();
            userControllers = new UtilisateurControllers();
        }

        public Frmlogin(Entities.Utilisateur user)
        {
            InitializeComponent();
            this.user = user;
            userControllers = new UtilisateurControllers();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmSignup().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string testObligatoire()
        {
            if(Username_txt.Text == "")
            {
                return "Entrer votre username";
            }
            if(password_txt.Text == "")
            {
                return "Entrer votre password";
            }

            return null;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.Utilisateur userCreated = userControllers.Save
                        (Username_txt.Text, password_txt.Text);
                if (userCreated != null)
                {
                    MessageBox.Show
                       (
                           $"Création de la fonction '{userCreated.NomUtilisateur}' éffectuée avec succès !",
                           "Succès",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                       );
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }

            if (testObligatoire() == null)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                exitApp = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(testObligatoire(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password_txt.UseSystemPasswordChar = true;
            }
            else
            {
                password_txt.UseSystemPasswordChar = false;
            }
        }
    }
}
