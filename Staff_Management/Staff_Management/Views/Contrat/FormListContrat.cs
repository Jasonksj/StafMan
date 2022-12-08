using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views.Contrat
{
    public partial class FormListContrat : UserControl
    {
        private static FormListContrat formList;

        public static FormListContrat Instance
        {
            get
            {
                if(formList == null)
                {
                    formList = new FormListContrat();
                }
                return formList;
            }
        }
        public FormListContrat()
        {
            InitializeComponent();
        }

        private void FormListContrat_Load(object sender, EventArgs e)
        {

        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormContrat formContrat = new FormContrat();
            formContrat.Show();
        }
    }
}
