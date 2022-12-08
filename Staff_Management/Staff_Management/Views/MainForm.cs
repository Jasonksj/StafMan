using Staff_Management.Views.Contrat;
using Staff_Management.Views.Employee;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_employee.Top;
            
        }

        private void btn_fonction_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_fonction.Top;
        }

        private void btn_paiement_Click(object sender, EventArgs e)
        {
            pnlbat.Top = btn_paiement.Top;
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
    }
}
