using Staff_Management.Views.Fonction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views.Mission
{
    public partial class FormListMission : UserControl
    {
        private static FormListMission formList;

        public static FormListMission Instance
        {
            get
            {
                if (formList == null)
                {
                    formList = new FormListMission();
                }
                return formList;
            }
        }
        public FormListMission()
        {
            InitializeComponent();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormMission formMission = new FormMission();
            formMission.Show();
        }
    }
}
