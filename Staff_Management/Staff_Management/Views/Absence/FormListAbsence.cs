using Staff_Management.Views.Contrat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views.Absence
{
    public partial class FormListAbsence : UserControl
    {
        private static FormListAbsence formList;

        public static FormListAbsence Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListAbsence();
                }
                return formList;
            }
        }
        public FormListAbsence()
        {
            InitializeComponent();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormAbsence formAbsence = new FormAbsence();
            formAbsence.Show();
        }
    }
}
