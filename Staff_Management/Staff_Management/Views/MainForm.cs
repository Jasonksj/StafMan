using Staff_Management.Views.Contrat;
using Staff_Management.Views.Departement;
using Staff_Management.Views.Employee;
using Staff_Management.Views.Absence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Staff_Management.Views.Fonction;
using Staff_Management.Views.Paiement;
using Staff_Management.Views.Conges;
using Staff_Management.Views.Mission;

namespace Staff_Management.Views
{
    public partial class MainForm : Form
    {
        bool exitApp = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Souhaitez-vous vraiment quitter ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;    
        }

        //private void AfficherPanel(object Form)
        //{
        //    if (this.main.Controls.Count > 0)

        //        this.main.Controls.RemoveAt(0);

        //    Form formul = Form as Form;
        //    formul.TopLevel = false;
        //    formul.Dock = DockStyle.Fill;

        //    this.main.Controls.Add(formul);
        //    this.main.Tag = formul;
        //    formul.Show();

        //}

        private void btn_dept_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_dept.Top;
            if (!main.Controls.Contains(FornListDepartement.Instance))
            {
                main.Controls.Add(FornListDepartement.Instance);
                FornListDepartement.Instance.Dock = DockStyle.Fill;
                FornListDepartement.Instance.BringToFront();
            }
            else
            {
                FornListDepartement.Instance.BringToFront();
            }
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_employee.Top;
            if (!main.Controls.Contains(FormListEmployee.Instance))
            {
                main.Controls.Add(FormListEmployee.Instance);
                FormListEmployee.Instance.Dock = DockStyle.Fill;
                FormListEmployee.Instance.BringToFront();
            }
            else
            {
                FormListEmployee.Instance.BringToFront();
            }

        }

        private void btn_fonction_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_fonction.Top;
            if (!main.Controls.Contains(FormListFonction.Instance))
            {
                main.Controls.Add(FormListFonction.Instance);
                FormListFonction.Instance.Dock = DockStyle.Fill;
                FormListFonction.Instance.BringToFront();
            }
            else
            {
                FormListFonction.Instance.BringToFront();
            }
        }

        private void btn_paiement_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_paiement.Top;
            if (!main.Controls.Contains(FormListPaiement.Instance))
            {
                main.Controls.Add(FormListPaiement.Instance);
                FormListPaiement.Instance.Dock = DockStyle.Fill;
                FormListPaiement.Instance.BringToFront();
            }
            else
            {
                FormListPaiement.Instance.BringToFront();
            }

        }

        private void btn_contrat_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_contrat.Top;
       
            if (!main.Controls.Contains(FormListContrat.Instance))
            {
                main.Controls.Add(FormListContrat.Instance);
                FormListContrat.Instance.Dock = DockStyle.Fill;
                FormListContrat.Instance.BringToFront();
            }
            else
            {
                FormListContrat.Instance.BringToFront();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exitApp)
                Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Time.Text = DateTime.Now.ToString();
            //if (DateTime.Now.Hour <= 12) Label_Intro.Text = "Bonjour " + Login.user + ", bienvenue dans StafMan.";
            //if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17) Label_Intro.Text = "Bonne apres-midi " + Login.user + ", bienvenue dans StafMan..";
            //if (DateTime.Now.Hour >= 18) Label_Intro.Text = "Bonsoir " + Login.user + ", bienvenue dans StafMan.";
        }

        private void btn_absence_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_absence.Top;

            if (!main.Controls.Contains(FormListAbsence.Instance))
            {
                main.Controls.Add(FormListAbsence.Instance);
                FormListAbsence.Instance.Dock = DockStyle.Fill;
                FormListAbsence.Instance.BringToFront();
            }
            else
            {
                FormListAbsence.Instance.BringToFront();
            }
        }

        private void btn_conges_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_conges.Top;

            if (!main.Controls.Contains(FormListConges.Instance))
            {
                main.Controls.Add(FormListConges.Instance);
                FormListConges.Instance.Dock = DockStyle.Fill;
                FormListConges.Instance.BringToFront();
            }
            else
            {
                FormListConges.Instance.BringToFront();
            }
        }

        private void btn_mission_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_mission.Top;

            if (!main.Controls.Contains(FormListMission.Instance))
            {
                main.Controls.Add(FormListMission.Instance);
                FormListMission.Instance.Dock = DockStyle.Fill;
                FormListMission.Instance.BringToFront();
            }
            else
            {
                FormListMission.Instance.BringToFront();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
