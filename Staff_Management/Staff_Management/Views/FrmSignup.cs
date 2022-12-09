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

namespace Staff_Management.Views
{
    public partial class FrmSignup : Form
    {
        EmployeeControllers empControllers;
        UtilisateurControllers utilControllers;

        public FrmSignup()
        {
            InitializeComponent();
            //string[] genders = { "Male", "Female", "Mix", "No gender", "Other" };
            //combo_gender.DataSource = genders;
            //combo_gender.SelectedIndex = -1;
            //Check_statut.Checked = true;
            //dateTimePicker1.Value = new DateTime(2000, 8, 16);
            empControllers = new EmployeeControllers();
            utilControllers = new UtilisateurControllers();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void register_but_Click(object sender, EventArgs e)
        {
            //fonctionControllers.Save(textBox2.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frmlogin().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSignup_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
