using Staff_Management.Controllers;
using Staff_Management.Entities;
using Staff_Management.Views.Absence;
using Staff_Management.Views.Fonction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static WinFormAnimation.AnimationFunctions;

namespace Staff_Management.Views.Conges
{
    public partial class FormListConges : System.Windows.Forms.UserControl
    {
        private static FormListConges formList;

        CongesControllers congesControllers;
    

        string defaultInput = "Search...";

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
            congesControllers = new CongesControllers();
            
        }

        private void btn_ajout_Click(object sender, EventArgs e)
        {
            FormConges formConges = new FormConges();
            formConges.Show();
        }
        private void CountItems()
        {
            label4.Text = (dataGridView1.Rows.Count - 1).ToString();
        }
        private int GetIdOfSelectedConges()
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
                            id = congesControllers.Findbyjustification(dataGridView1.SelectedRows[i].Cells[5].Value.ToString()).IdConges;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            PopulateDataGridView(congesControllers.FindAll());
            CountItems();
            textBox1.SelectAll();
        }

        private void PopulateDataGridView(List<Conge> conges)
        {
            dataGridView1.Rows.Clear();

            conges.ForEach
                (
                    delegate (Entities.Conge conge)
                    {
                        dataGridView1.Rows.Add(false, conge.DateDebut,conge.DateFin,conge.Justification);
                    }
                );
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetIdOfSelectedConges();

                if (id != -1)
                {
                    int issue = congesControllers.Delete(id);
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetIdOfSelectedConges();
                if (id != -1)
                {
                    FormConges formConges = new FormConges
                        (congesControllers.FindById(id));
                    formConges.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

    }
}
