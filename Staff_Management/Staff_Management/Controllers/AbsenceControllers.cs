using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Entities;
using Staff_Management.Services;

namespace Staff_Management.Controllers
{
    public class AbsenceControllers
    {
        AbsenceServices absenceServices;

        public AbsenceControllers()
        {
            absenceServices = new AbsenceServices();
        }

        public Absence Save(string motif, double pourcentagePerte)
        {
            Absence absence = new Absence
            {
                Motif = motif,
                PourcentagePerte = pourcentagePerte
            };
            return absenceServices.Save(absence);
        }

        public Absence Update(Absence absence)
        {
            return absenceServices.Update(absence);
        }

        public int Delete(int id)
        {
            return absenceServices.Delete(id);
        }

        public List<Absence> FilterByMotif(string motif)
        {
            return absenceServices.FilterByMotif(motif);
        }

        public bool Exists(int id)
        {
            return absenceServices.Exists(id);
        }

        public bool Exists(string motif)
        {
            return absenceServices.Exists(motif);
        }

        public List<Absence> FindAll()
        {
            return absenceServices.FindAll();
        }
    }
}
