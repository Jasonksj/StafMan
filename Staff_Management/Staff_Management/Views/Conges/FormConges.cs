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
using static WinFormAnimation.AnimationFunctions;
using System.Xml.Linq;
using Staff_Management.Controllers;

namespace Staff_Management.Views.Conges
{
    public partial class FormConges : Form
    {
        CongesControllers congesControllers;
        Entities.Conge conge;
        bool isUpdateForm;
        public FormConges()
        {
            InitializeComponent();
        }

        public FormConges(Conge conge)
        {
            InitializeComponent();
            this.conge = conge;
            isUpdateForm = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadForm()
        {
            if (!isUpdateForm)
                label1.Text = "AJOUT D'UN CONGE";
            else
            {
                label1.Text = "MODIFICATION D'UN CONGE";
                textBox1.Text = conge.Justification;
                textBox1.Select();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUpdateForm)
                {
                    conge.Justification = textBox1.Text;
                    Entities.Conge congesUpdated = congesControllers.Update
                        (conge);
                    if (congesUpdated != null)
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
                    Entities.Conge fonctionCreated = congesControllers.Save
                        (dateTimePicker1.Value, dateTimePicker2.Value, textBox1.Text, float.Parse(textBox2.Text));
                    if (fonctionCreated != null)
                    {
                        MessageBox.Show
                           (
                               $"Création de la demande de conges éffectuée avec succès !",
                               "Succès",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information
                           );
                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        private void FormConges_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

       