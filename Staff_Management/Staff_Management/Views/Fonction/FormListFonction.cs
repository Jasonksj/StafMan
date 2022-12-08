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

namespace Staff_Management.Views.Fonction
{
    public partial class FormListFonction : UserControl
    {
        private static FormListFonction formList;

        public static FormListFonction Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListFonction();
                }
                return formList;
            }
        }
        public FormListFonction()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormFonction formFonction = new FormFonction();
            formFonction.Show();
        }
    }
}
