using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views
{
    public partial class FrmSignup : Form
    {
        public FrmSignup()
        {
            InitializeComponent();
            string[] genders = { "Male", "Female", "Mix", "No gender", "Other" };
            combo_gender.DataSource = genders;
            combo_gender.SelectedIndex = -1;
            Panel.Checked = true;
            D_T_birthday.Value = new DateTime(2000, 8, 16);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void register_but_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frmlogin().Show();
            this.Hide();
        }
    }
}
