using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Services;
using Staff_Management.Entities;
using System.Runtime.InteropServices;

namespace Staff_Management.Controllers
{
    public class UtilisateurControllers
    {

        UtilisateurServices utilisateurServices;

        public UtilisateurControllers()
        {
            utilisateurServices = new UtilisateurServices();
        }

        public Utilisateur Save(int id, string name, string password)
        {
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.IdUtilisateur = ++id;
            utilisateur.NomUtilisateur = name;
            utilisateur.MotDePasse = password;
            return utilisateurServices.Save(utilisateur);
        }
    }
}
