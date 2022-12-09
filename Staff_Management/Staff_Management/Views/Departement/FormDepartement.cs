using Staff_Management.Controllers;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static WinFormAnimation.AnimationFunctions;

namespace Staff_Management.Views.Departement
{
    public partial class FormDepartement : Form
    {
        bool isUpdateDepartement;

        DepartementControllers departementControllers;

        EmployeeControllers employeeControllers;

        Entities.Departement departement;

        Entities.Employee employee;
        public FormDepartement()
        {
            InitializeComponent();
            isUpdateDepartement = false;
            departementControllers = new DepartementControllers();
        }

        public FormDepartement(Entities.Departement departement, Entities.Employee employee)
        {
            InitializeComponent();
            this.departement = departement;
            isUpdateDepartement = true;
            departementControllers = new DepartementControllers();
            employeeControllers = new EmployeeControllers();
            this.employee = employee;
        }

        public FormDepartement(Entities.Departement departement)
        { 
            InitializeComponent();
            this.departement = departement;
            isUpdateDepartement = true;
            departementControllers = new DepartementControllers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadForm()
        {
            if (!isUpdateDepartement)
                lbl_title.Text = "AJOUT D'UN DEPARTEMENT";
            else
            {
                lbl_title.Text = "MODIFICATION D'UN DEPARTEMENT";
                nomdepartement_txt.Text = departement.Nom;
                nomdepartement_txt.Select();
            }
        }

        private void btn_valid_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUpdateDepartement)
                {
                    departement.Nom = nomdepartement_txt.Text;
                    Entities.Departement departementUpdated = departementControllers.Update
                        (departement);
                    if (departementUpdated != null)
                    {
                        MessageBox.Show
                            (
                                "Modification éffectuée avec succès !",
                                "Succès",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        Close();
                    }
                }
                else
                {
                    Entities.Departement departementCreated = departementControllers.Save
                        (nomdepartement_txt.Text, employee.IdManager.Value);
                    if (departementCreated != null)
                    {
                        MessageBox.Show
                           (
                               $"Création du departement '{departementCreated.Nom}' éffectuée avec succès !",
                               "Succès",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information
                           );
                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        private void FormDepartement_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
