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

namespace Staff_Management.Views.Employee
{
    public partial class FormAddEmployee : Form
    {
        EmployeeControllers empControllers;
        bool isUpdatingForm;
        Entities.Employee emp;

        public FormAddEmployee()
        {
            InitializeComponent();
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
