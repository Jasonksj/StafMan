using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Staff_Management.Controllers;

namespace Staff_Management.Views.Fonction
{
    public partial class FormFonction : Form
    {
        bool isUpdateForm;

        FonctionControllers fonctionControllers;

        Entities.Fonction fonction;

        public FormFonction()
        {
            InitializeComponent();
            isUpdateForm = false;
            fonctionControllers = new FonctionControllers();
        }

        public FormFonction(Entities.Fonction fonction)
        {
            InitializeComponent();
            this.fonction = fonction;
            isUpdateForm = true;
            fonctionControllers = new FonctionControllers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFonction_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            if (!isUpdateForm)
                lblTitle.Text = "AJOUT D'UNE FONCTION";
            else
            {
                lblTitle.Text = "MODIFICATION D'UNE FONCTION";
                txtName.Text = fonction.Nom;
                txtName.Select();
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUpdateForm)
                {
                    fonction.Nom = txtName.Text;
                    Entities.Fonction fonctionUpdated = fonctionControllers.Update
                        (fonction);
                    if (fonctionUpdated != null)
                    {
                        MessageBox.Show
                            (
                                "Modification éffectuée avec succès !",
                                "Succès",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        Close();
                    }
                }
                else
                {
                    Entities.Fonction fonctionCreated = fonctionControllers.Save
                        (txtName.Text);
                    if (fonctionCreated != null)
                    {
                        MessageBox.Show
                           (
                               $"Création de la fonction '{fonctionCreated.Nom}' éffectuée avec succès !",
                               "Succès",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information
                           );
                        Close();
                    }

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
