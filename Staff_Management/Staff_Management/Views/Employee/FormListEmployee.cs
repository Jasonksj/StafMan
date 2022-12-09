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
    public partial class FormListEmployee : UserControl
    {
        private static FormListEmployee formList;

        EmployeeControllers empControllers;

        DepartementControllers deptControllers;



        public static FormListEmployee Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListEmployee();
                }
                return formList;
            }
        }
        public FormListEmployee()
        {
            InitializeComponent();
            empControllers = new EmployeeControllers();
            deptControllers = new DepartementControllers();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FrmSignup frmSignup = new FrmSignup();
            frmSignup.ShowDialog();
        }

        private void FormListEmployee_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            PopulateDataGridView(empControllers.FindAll());
            CountItems();
            textBox1.SelectAll();
        }

        private void PopulateDataGridView(List<Entities.Employee> employees)
        {
            dataGridView1.Rows.Clear();

            employees.ForEach
                (
                    delegate(Entities.Employee employee)
                    {
                        dataGridView1.Rows.Add
                        (
                            false,
                            employee.Nom,
                            employee.Email,
                            employee.Adresse,
                            employee.Telephone,
                            employee.DateEmbauche,
                            empControllers.FindById((int)employee.IdManager).Nom,
                            deptControllers.FindById(employee.IdDept).Nom
                        );
                    }
                );
        }

        private void CountItems()
        {
            label4.Text = (dataGridView1.Rows.Count - 1).ToString();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
