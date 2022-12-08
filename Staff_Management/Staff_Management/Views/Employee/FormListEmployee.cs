using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views.Employee
{
    public partial class FormListEmployee : UserControl
    {
        private static FormListEmployee formList;

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
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee();
            formAddEmployee.Show();
        }
    }
}
