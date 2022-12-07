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
    public class EmployeeService
    {
        EmployeeDAO employeeDAO;
        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
        }

        public bool Exists(int id)
        {
            return employeeDAO.Exist(id);
        }

        public bool Exists(string name)
        {
            List<Employee> employees = FindAll();
            List<Employee> foundEmployees = employees.FindAll
                (
                    mainEmployee => mainEmployee.Nom == name
                );

            return foundEmployees.Count > 0;
        }

        public Employee Save(Employee employee)
        {
            try
            {
                if (!Exists(employee.Nom))
                    return employeeDAO.Save(employee);
                else
                {
                    MessageBox.Show
                        (
                            $"L'employé  '{employee.Nom} existe déjà !",
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

        public Employee Update(Employee employee)
        {
            try
            {
                if (Exists(employee.Id))
                    return employeeDAO.Update(employee);
                else
                {
                    MessageBox.Show
                        (
                            $"L'employé '{employee.Nom} n'existe pas !",
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

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return employeeDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            $"Cet employé n'existe pas !",
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

        public List<Employee> FindAll()
        {
            return employeeDAO.FindAll();
        }

        public Employee FindByName(string name)
        {
            List<Employee> employees = FindAll();
            return employees.Find(mainEmployee => mainEmployee.Nom == name);
        }

        public List<Employee> FilterByName(string name)
        {
            try
            {
                return FindAll().Where
                (
                    mainEmployee => mainEmployee.Nom.IndexOf
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

        public Employee FindTheManagerOf(Employee employee)
        {
            try
            {
                return FindAll().Find
                    (
                        manager => manager.Id == employee.IdManager
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Employee> FindTheEmployeesOf(Employee manager)
        {
            try
            {
                return FindAll().FindAll
                    (
                        employee => employee.IdManager == manager.Id
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
