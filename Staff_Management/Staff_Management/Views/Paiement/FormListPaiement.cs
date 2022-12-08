using Staff_Management.Views.Mission;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views.Paiement
{
    public partial class FormListPaiement : UserControl
    {
        private static FormListPaiement formList;

        public static FormListPaiement Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListPaiement();
                }
                return formList;
            }
        }
        public FormListPaiement()
        {
            InitializeComponent();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormPaiement formPaiement = new FormPaiement();
            formPaiement.Show();
        }
    }
}
