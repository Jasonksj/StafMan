using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Entities;
using Staff_Management.Services;

namespace Staff_Management.Controllers
{
    public class ContratControllers
    {
        ContratServices contratServices;

        public ContratControllers()
        {
            contratServices = new ContratServices();
        }

        public Contrat Save(int idEmployee, DateTime dateDebut, string titre, string niveauHierachique, 
            string type, float salaire, DateTime dateFin, int idFonction)
        {
            Contrat contrat = new Contrat
            {
                IdEmployee = idEmployee,
                DateDebutContrat = dateDebut,
                Titre = titre,
                NiveauHierachique = niveauHierachique,
                Type = type,
                Salaire = salaire,
                DateFin = dateFin,
                IdFonction = idFonction
            };
            return contratServices.Save(contrat);
        }

        public int Delete(int idEmployee, DateTime dateDebut, string title)
        {
            return contratServices.Delete(idEmployee, dateDebut, title);
        }

        public Contrat Update(Contrat contrat)
        {
            return contratServices.Update(contrat);
        }

        public Contrat Find(string title, int idEmploye, DateTime dateDebut)
        {
            return contratServices.Find(title, idEmploye, dateDebut);
        }

        public List<Contrat> FindAll()
        {
            return contratServices.FindAll();
        }

        public List<Contrat> FilterByName(string name)
        {
            return contratServices.FilterByName(name);
        }

        public List<Mission> GetMissionList(Contrat contrat)
        {
            return contratServices.GetMissionList(contrat);
        }

        public bool Exists(string name, int idEmploye, DateTime dateDebut)
        {
            return contratServices.Exists(name, idEmploye, dateDebut);
        }
    }
}
