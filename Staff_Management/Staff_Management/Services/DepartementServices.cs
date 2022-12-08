using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Services
{
    public  class DepartementServices
    {
        DepartementDAO departementDAO;

        EmployeeService employeeService;

        public DepartementServices()
        {
            departementDAO = new DepartementDAO();
            employeeService = new EmployeeService();
        }

        public bool Exists(int id)
        {
            return departementDAO.Exists(id);
        }


        public List<Departement> FindAll()
        {
            return departementDAO.FindAll();
        }

        public Departement FindById(int id)
        {
            try
            {
                return FindAll().Find(dept => dept.IdDept == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(string name)
        {
            try
            {
                List<Departement> departements = FindAll();
                List<Departement> foundDepartements = departements.FindAll
                    (
                        departement => departement.Nom == name
                    );

                return foundDepartements.Count > 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Departement FindByName(string name)
        {
            List<Departement> departements = FindAll();
            return departements.Find(departement => departement.Nom == name);
        }

        public Departement Save(Departement departement)
        {
            try
            {
                if (!Exists(departement.Nom))
                    return departementDAO.Save(departement);
                else
                {
                    MessageBox.Show
                        (
                            $"Le departement '{departement.Nom} existe déjà !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Departement> FilterByName(string name)
        {
            try
            {
                return FindAll().Where
                (
                    departement => departement.Nom.IndexOf
                    (
                        name,
                        StringComparison.CurrentCultureIgnoreCase
                    ) != -1
                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }


        public Departement Update(Departement departement)
        {
            try
            {
                bool hasThisNameHere = Exists(departement.Nom);
                bool hasThisIdHere = Exists(departement.IdDept);
                if (hasThisIdHere && !hasThisNameHere)
                    return departementDAO.Update(departement);
                else if (!hasThisIdHere)
                    MessageBox.Show
                        (
                            $"Ce département n'existe pas !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                else if (hasThisNameHere)
                    MessageBox.Show
                        (
                            $"Le departement '{departement.Nom} existe déjà !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return departementDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            $"Cette fonction n'existe pas !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Employee FindManager(Departement departement)
        {
            try
            {
                return employeeService.FindAll().Find
                    (
                        employe => employe.Id == departement.IdManager
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Employee> GetEmployeesList(Departement departement)
        {
            try
            {
                return employeeService.FindAll().FindAll
                    (
                        employe => employe.IdDept == departement.IdDept           
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
