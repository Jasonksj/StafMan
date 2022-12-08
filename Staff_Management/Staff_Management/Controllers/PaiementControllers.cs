using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Entities;
using Staff_Management.Services;

namespace Staff_Management.Controllers
{
    public class PaiementControllers
    {
        PaiementServices paiementServices;

        public PaiementControllers()
        {
            paiementServices = new PaiementServices();
        }

        public Paiement Save(int idEmploye, DateTime dateVersement, DateTime dateDebutContrat,
            Nullable<int> idAbsence, Nullable<int> idConge, Nullable<int> idMission)
        {
            Paiement paiement = new Paiement
            {
                IdEmployee = idEmploye,
                DateVersement = dateVersement,
                DateDebutContrat = dateDebutContrat,
                IdAbsence = idAbsence,
                IdConges = idConge,
                IdMission = idMission
            };
            return paiementServices.Save(paiement);
        }

        public Paiement Update(Paiement paiement)
        {
            return paiementServices.Update(paiement);
        }

        public int Delete(int id, DateTime dateVersement)
        {
            return paiementServices.Delete(id, dateVersement);
        }

        public List<Paiement> FindAll()
        {
            return paiementServices.FindAll();
        }

        public List<Paiement> FilterByStartDateAccord(DateTime startDateAccord)
        {
            return paiementServices.FilterByStartDateAccord(startDateAccord);
        }

        public Paiement Find(int idEmployee, DateTime transactionDate)
        {
            return paiementServices.Find(idEmployee, transactionDate);
        }

        public bool Exists(int idEmployee, DateTime transactionDate)
        {
            return paiementServices.Exists(idEmployee, transactionDate);
        }
    }
}
