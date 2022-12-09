using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Staff_Management.Entities;
using Staff_Management.Services;

namespace Staff_Management.Controllers
{
    public class DepartementControllers
    {
        DepartementServices deptServices;

        public DepartementControllers()
        {
            deptServices = new DepartementServices();
        }

        public Departement Save(string name, int idManager)
        {
            Departement dept = new Departement
            {
                Nom = name,
                IdManager = idManager
            };
            return deptServices.Save(dept);
        }

        public Departement Update(Departement departement)
        {
            return deptServices.Update(departement);
        }

        public int Delete(int id)
        {
            return deptServices.Delete(id);
        }

        public List<Departement> FindAll()
        {
            return deptServices.FindAll();
        }

        public Departement FindByName(string name)
        {
            return deptServices.FindByName(name);
        }

        public Departement FindById(int id)
        {
            return deptServices.FindById(id);
        }

        public List<Departement> FilterByName(string name)
        {
            return deptServices.FilterByName(name);
        }

        public Employee FindManager(Departement departement)
        {
            return deptServices.FindManager(departement);
        }

        public List<Employee> GetEmployeesList(Departement departement)
        {
            return deptServices.GetEmployeesList(departement);
        }

        public Departement FindById(int id)
        {
            return deptServices.FindById(id);
        }

        public bool Exists(int id)
        {
            return deptServices.Exists(id);
        }

        public bool Exists(string name)
        {
            return deptServices.Exists(name);
        }
    }
}
