using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.DAO
{
    public class EmployeeDAO
    {
        StafManEntities staffManag;

        Employee mainEmployee;

        public EmployeeDAO()
        {
            staffManag = new StafManEntities();
            mainEmployee = new Employee();
        }

        public Employee Save(Employee employee)
        {
            try
            {
                mainEmployee = employee;
                staffManag.Employees.Add(mainEmployee);
                staffManag.SaveChanges();
                return mainEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement de l'employé '{employee.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idEmployee)
        {
            try
            {
                mainEmployee = staffManag.Employees.FirstOrDefault
                (
                    fonction => (fonction.Id == idEmployee)
                );
                staffManag.Employees.Remove(mainEmployee);
                staffManag.SaveChanges();
                return mainEmployee.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                        $"Suppression de l'employé impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exist(int idEmployee)
        {
            try
            {
                return staffManag.Employees.FirstOrDefault
                (
                    fonction => fonction.Id == idEmployee
                ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public List<Employee> FindAll()
        {
            try
            {
                return staffManag.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public Employee Update(Employee employee)
        {
            try
            {
                mainEmployee = employee;
                staffManag.SaveChanges();
                return mainEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification de l'employé '{employee.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
