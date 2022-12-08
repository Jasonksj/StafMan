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

        public bool Exists(int idEmployee, DateTime transactionDate)
        {
            return paiementDAO.Exists(idEmployee, transactionDate);
        }

        public List<Paiement> FindAll()
        {
            return paiementDAO.FindAll();
        }

        public List<Paiement> FilterByStartDateAccord(DateTime startDateAccord)
        {
            try
            {
                return FindAll().FindAll(paiement => paiement.DateDebutContrat == startDateAccord);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Paiement Find(int idEmployee, DateTime transactionDate)
        {
            try
            {
                return FindAll().Find
                    (
                        paiement => paiement.IdEmployee == idEmployee &&
                                    paiement.DateVersement == transactionDate
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
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

        public int Delete(int id, DateTime dateVersement)
        {
            try
            {
                if (Exists(id, dateVersement))
                    return paiementDAO.Delete(id, dateVersement);
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
