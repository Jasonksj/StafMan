using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Services
{
    public class PaiementServices
    {
        PaiementDAO paiementDAO;

        public PaiementServices()
        {
            paiementDAO = new PaiementDAO();
        }

        public bool Exists(int id, DateTime dateDebut)
        {
            return paiementDAO.Exists(id, dateDebut);
        }

        public List<Paiement> FindAll()
        {
            return paiementDAO.FindAll();
        }

        public Paiement Save(Paiement paiement)
        {
            try
            {
                return paiementDAO.Save(paiement);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Paiement Update(Paiement paiement)
        {
            try
            {
                return paiementDAO.Update(paiement);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Delete(int id, DateTime dateDebut)
        {
            try
            {
                if (Exists(id, dateDebut))
                    return paiementDAO.Delete(id, dateDebut);
                else
                {
                    MessageBox.Show
                        (
                            $"Ce paiement n'existe pas !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
