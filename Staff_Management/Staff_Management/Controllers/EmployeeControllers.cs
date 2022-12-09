using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Entities;
using Staff_Management.Services;

namespace Staff_Management.Controllers
{
    public class EmployeeControllers
    {
        EmployeeService empServices;

        public EmployeeControllers()
        {
            empServices = new EmployeeService();
        }

        public Employee Save(string Nom, string Email, byte[] Picture,
            string Adresse, string Telephone, DateTime DateEmbauche, int IdDept, Nullable<int> IdManager)
        {
            Employee employee = new Employee
            {
                Nom = Nom,
                Email = Email,
                Picture = Picture,
                Adresse = Adresse,
                Telephone = Telephone,
                DateEmbauche = DateEmbauche,
                IdDept = IdDept,
                IdManager = IdManager
            };
            return empServices.Save(employee);
        }

        public Employee Update(Employee employee)
        {
            return empServices.Update(employee);
        }

        public int Delete(int id)
        {
            return empServices.Delete(id);
        }

        public bool Exists(int id)
        {
            return empServices.Exists(id);
        }

        public bool Exists(string name)
        {
            return empServices.Exists(name);
        }

        public List<Employee> FindAll()
        {
            return empServices.FindAll();
        }

        public Employee FindByName(string name)
        {
            return empServices.FindByName(name);
        }

        public List<Employee> FilterByName(string name)
        {
            return empServices.FilterByName(name);
        }

        public List<Employee> FilterByHireDate(DateTime hireDate)
        {
            return empServices.FilterByHireDate(hireDate);
        }

        public List<Employee> FilterByDepartment(int idDept)
        {
            return empServices.FilterByDepartment(idDept);
        }

        public List<Employee> FilterByManager(int idManager)
        {
            return empServices.FilterByManager(idManager);
        }

        public Employee FindTheManagerOf(Employee employee)
        {
            return empServices.FindTheManagerOf(employee);
        }

        public List<Employee> FindTheEmployeesOf(Employee manager)
        {
            return empServices.FindTheEmployeesOf(manager);
        }

        public List<Contrat> GetContratsList(Employee employee)
        {
            return empServices.GetContratsList(employee);
        }

        public List<Mission> GetAttributedMissionsList(Employee manager)
        {
            return empServices.GetAttributedMissionsList(manager);
        }

        public Employee FindById(int id) 
        {
            return empServices.FindById(id);
        }
    }
}
