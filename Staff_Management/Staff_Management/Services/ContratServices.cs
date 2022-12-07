using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff_Management.Services
{
    public class ContratServices
    {
        ContratDAO contratDAO;

        public ContratServices()
        {
            contratDAO = new ContratDAO();
        }
    }
}
