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
            Utilisateur utilisateur = new Utilisateur
            {
                IdUtilisateur = id,
                NomUtilisateur = name,
                MotDePasse = password
            };
            return utilisateurServices.Save(utilisateur);
        }

        public int Delete(int id)
        {
            return utilisateurServices.Delete(id);
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            return utilisateurServices.Update(utilisateur);
        }

        public List<Utilisateur> FindAll()
        {
            return utilisateurServices.FindAll();
        }

        public List<Utilisateur> FilterByUsername(string username)
        {
            return utilisateurServices.FilterByUsername(username);
        }

        public Utilisateur Find(string username, string password)
        {
            return utilisateurServices.Find(username, password);
        }

        public Employee FindTheCorrespondingEmployee(Utilisateur utilisateur)
        {
            return utilisateurServices.FindCorrespondingEmployee(utilisateur);
        }

        public bool Exists(int id)
        {
            return utilisateurServices.Exists(id);
        }

        public bool Exists(string name, string password)
        {
            return utilisateurServices.Exists(name, password);
        }
    }
}
