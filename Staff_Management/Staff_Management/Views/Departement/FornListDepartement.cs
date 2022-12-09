using Staff_Management.Controllers;
using Staff_Management.Views.Contrat;
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

namespace Staff_Management.Views.Departement
{
    public partial class FornListDepartement : UserControl
    {
        private static FornListDepartement formList;

        DepartementControllers departementControllers;

        EmployeeControllers employeeControllers;

        string defaultInput = "Search...";

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
            departementControllers= new DepartementControllers();
            employeeControllers= new EmployeeControllers();
        }

        private void PopulateDataGridView(List<Entities.Departement> departements)
        {
            dataGridView1.Rows.Clear();
            departements.ForEach
                (
                    delegate (Entities.Departement departement)
                    {
                        dataGridView1.Rows.Add
                        (
                            false,
                            departement.Nom,
                            employeeControllers.FindById(departement.IdManager).Nom

                        );
                    }
                );

        }

        private void LoadForm()
        {
            PopulateDataGridView(departementControllers.FindAll());
            CountItems();
            txt_search.SelectAll();
        }

        private void CountItems()
        {
            lblcount.Text = (dataGridView1.Rows.Count - 1).ToString();
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormDepartement formDepartement = new FormDepartement();
            formDepartement.ShowDialog();
        }

        private void FornListDepartement_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txt_search.Text;
                if (input.Length == 0)
                {
                    txt_search.Text = defaultInput;
                    txt_search.SelectAll();
                }
                else
                {
                    PopulateDataGridView(departementControllers.FilterByName(input));
                    CountItems();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetIdOfSelectedFonction();

                if (id != -1)
                {
                    int issue = departementControllers.Delete(id);
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
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        private int GetIdOfSelectedFonction()
        {
            try
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
                            id = departementControllers.FindByName(dataGridView1.SelectedRows[i].Cells[1].Value.ToString()).IdDept;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetIdOfSelectedFonction();
                if (id != -1)
                {
                    FormDepartement formFonction = new FormDepartement
                        (departementControllers.FindById(id));
                    formFonction.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}