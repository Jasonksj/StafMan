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
using Staff_Management.Controllers;

namespace Staff_Management.Views.Fonction
{
    public partial class FormListFonction : UserControl
    {
        private static FormListFonction formList;

        FonctionControllers fonctionControllers;

        string defaultInput = "Search...";

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
            fonctionControllers = new FonctionControllers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormFonction formFonction = new FormFonction();
            formFonction.ShowDialog();
        }

        private void FormListFonction_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            PopulateDataGridView(fonctionControllers.FindAll());
            CountItems();
            txtSearch.SelectAll();
        }

        private void PopulateDataGridView(List<Entities.Fonction> fonctions)
        {
            dataGridView1.Rows.Clear();

            fonctions.ForEach
                (
                    delegate(Entities.Fonction fonction)
                    {
                        dataGridView1.Rows.Add(false, fonction.Nom);
                    }
                );
        }

        private void CountItems()
        {
            lblCount.Text = (dataGridView1.Rows.Count - 1).ToString();
        }

        private void FilterByInput(object sender, EventArgs e)
        {
            string input = txtSearch.Text;
            if (input.Length == 0)
            {
                txtSearch.Text = defaultInput;
                txtSearch.SelectAll();
            }
            else
            {
                PopulateDataGridView(fonctionControllers.FilterByName(input));
                CountItems();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = GetIdOfSelectedFonction();

            if(id != -1)
            {
                int issue = fonctionControllers.Delete(id);
                if (issue != -1)
                    MessageBox.Show
                        (
                            "Suppression éffectuée avec succès !",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
            }
        }

        private int GetIdOfSelectedFonction()
        {
            int id = -1;
            int selectedRows = dataGridView1.SelectedRows.Count;

            if (selectedRows < 1)
                MessageBox.Show
                    (
                        "Vous n'avez sélectionné aucune ligne !",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            else if (selectedRows > 1)
                MessageBox.Show
                    (
                        "Vous avez sélectionné beaucoup trop de lignes !",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            else
            {
                for (int i = 0; i < selectedRows; i++)
                {
                    if ((bool)dataGridView1.SelectedRows[i].Cells[0].Value == true)
                        id = fonctionControllers.FindByName(dataGridView1.SelectedRows[i].Cells[1].Value.ToString()).IdFonction;
                }
            }

            return id;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = GetIdOfSelectedFonction();
            if(id != -1)
            {
                FormFonction formFonction = new FormFonction
                    (fonctionControllers.FindById(id));
                formFonction.ShowDialog();
            }
            
        }
    }
}
