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
            Fonction fonction = new Fonction();
            fonction.Nom = nom;
            return fonctionServices.Save(fonction);
        }
    }
}
