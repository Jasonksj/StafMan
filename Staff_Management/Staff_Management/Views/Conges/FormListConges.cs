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

namespace Staff_Management.Views.Conges
{
    public partial class FormListConges : UserControl
    {
        private static FormListConges formList;

        public static FormListConges Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListConges();
                }
                return formList;
            }
        }
        public FormListConges()
        {
            InitializeComponent();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormConges formConges = new FormConges();
            formConges.Show();
        }
    }
}
