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

namespace Staff_Management.Views.Departement
{
    public partial class FornListDepartement : UserControl
    {
        private static FornListDepartement formList;

        public static FornListDepartement Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FornListDepartement();
                }
                return formList;
            }
        }
        public FornListDepartement()
        {
            InitializeComponent();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormDepartement formDepartement = new FormDepartement();
            formDepartement.Show();
        }
    }
}
