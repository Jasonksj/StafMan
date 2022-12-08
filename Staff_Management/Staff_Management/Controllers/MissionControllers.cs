using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Services;
using Staff_Management.Entities;

namespace Staff_Management.Controllers
{
    public class MissionControllers
    {
        MissionServices missionServices;

        public MissionControllers()
        {
            missionServices = new MissionServices();
        }

        public Mission Save(float Montant, DateTime DateDebut, DateTime DateFin, 
            string Intitule, int IdManager, int IdEmployee, DateTime DateDebutContrat)
        {
            Mission mission = new Mission
            {
                Montant = Montant,
                DateDebut = DateDebut,
                DateFin = DateFin,
                Intitule = Intitule,
                IdManager = IdManager,
                IdEmployee = IdEmployee,
                DateDebutContrat = DateDebutContrat
            };
            return missionServices.Save(mission);
        }

        public int Delete(int id)
        {
            return missionServices.Delete(id);
        }

        public Mission Update(Mission mission)
        {
            return missionServices.Update(mission);
        }

        public List<Mission> FindAll()
        {
            return missionServices.FindAll();
        }

        public List<Mission> FilterByName(string name)
        {
            return missionServices.FilterByName(name);
        }

        public List<Mission> FilterByStartDate(DateTime startDate)
        {
            return missionServices.FilterByStartDate(startDate);
        }

        public List<Mission> FilterByEndDate(DateTime endDate)
        {
            return missionServices.FilterByEndDate(endDate);
        }

        public List<Mission> FilterByAccordStartDate(DateTime accordStartDate)
        {
            return missionServices.FilterByAccordStartDate(accordStartDate);
        }

        public Mission FindByName(string name)
        {
            return missionServices.FindByName(name);
        }

        public bool Exists(int id)
        {
            return missionServices.Exists(id);
        }
    }
}
