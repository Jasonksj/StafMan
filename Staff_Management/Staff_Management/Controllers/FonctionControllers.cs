using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Services;
using Staff_Management.Entities;

namespace Staff_Management.Controllers
{
    public class FonctionControllers
    {
        FonctionServices fonctionServices;

        public FonctionControllers()
        {
            fonctionServices = new FonctionServices();
        }

        public Fonction Save(string nom)
        {
            Fonction fonction = new Fonction
            {
                Nom = nom
            };
            return fonctionServices.Save(fonction);
        }

        public Fonction Update(Fonction fonction)
        {
            return fonctionServices.Update(fonction);
        }

        public int Delete(int id)
        {
            return fonctionServices.Delete(id);
        }

        public bool Exists(int id)
        {
            return fonctionServices.Exists(id);
        }

        public bool Exists(string name)
        {
            return fonctionServices.Exists(name);
        }

        public List<Fonction> FindAll()
        {
            return fonctionServices.FindAll();
        }

        public Fonction FindByName(string name)
        {
            return fonctionServices.FindByName(name);
        }

        public Fonction FindById(int id)
        {
            return fonctionServices.FindById(id);
        }

        public List<Fonction> FilterByName(string name)
        {
            return fonctionServices.FilterByName(name);
        }
    }
}
