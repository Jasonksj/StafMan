using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staff_Management.Services;
using Staff_Management.Entities;

namespace Staff_Management.Controllers
{
    public class CongesControllers
    {
        CongesServices congesServices;

        public CongesControllers()
        {
            congesServices = new CongesServices();
        }

        public Conge Save(DateTime startDate, DateTime endDate, string justification, float percentLost)
        {
            Conge conge = new Conge
            {
                DateDebut = startDate,
                DateFin = endDate,
                Justification = justification,
                PourcentageRetrait = percentLost
            };
            return congesServices.Save(conge);
        }

        public Conge Update(Conge conge)
        {
            return congesServices.Update(conge);
        }

        public int Delete(int id)
        {
            return congesServices.Delete(id);
        }

        public List<Conge> FindAll()
        {
            return congesServices.FindAll();
        }

        public List<Conge> FilterAllByStartDate(DateTime startDate)
        {
            return congesServices.FilterAllByStartDate(startDate);
        }

        public List<Conge> FilterAllByEndDate(DateTime endDate)
        {
            return congesServices.FilterAllByEndDate(endDate);
        }

        public List<Conge> FilterByPercentLost(float percentLost)
        {
            return congesServices.FilterByPercentLost(percentLost);
        }

        public Conge FindById(int id)
        {
            return congesServices.FindById(id);
        }

        public bool Exists(int id)
        {
            return congesServices.Exists(id);
        }

        public bool Exists(string justification)
        {
            return congesServices.Exists(justification);
        }
        public Conge Findbyjustification(string justification)
        {
            return congesServices.Findbyjustification(justification);
        }
        
    }
}
