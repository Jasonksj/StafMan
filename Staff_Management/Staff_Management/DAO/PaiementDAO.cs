using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.DAO
{
    public class PaiementDAO
    {
        StafManEntities staffManag;

        Paiement mainPaiement;
        Employee employee1;

        public PaiementDAO()
        {
            staffManag = new StafManEntities();
            mainPaiement = new Paiement();
            employee1 = new Employee();
        }

        public Paiement Save(Paiement paiement)
        {
            try
            {
                mainPaiement = paiement;
                staffManag.Paiements.Add(mainPaiement);
                staffManag.SaveChanges();
                return mainPaiement;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Paiement de l'employé '{employee1.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idEmployee, DateTime dateDebut)
        {
            try
            {
                mainPaiement = staffManag.Paiements.FirstOrDefault
                (
                    mainPaiement => mainPaiement.IdEmployee == idEmployee &&
                                   mainPaiement.DateDebutContrat == dateDebut
                );
                staffManag.Paiements.Remove(mainPaiement);
                staffManag.SaveChanges();
                return mainPaiement.IdEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                        $"Suppression du paiement de l'employé impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exists(int id, DateTime dateDebut)
        {
            try
            {
                return staffManag.Paiements.SingleOrDefault
                    (
                        mainPaiement => mainPaiement.IdEmployee == id &&
                                   mainPaiement.DateDebutContrat == dateDebut
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Paiement> FindAll()
        {
            try
            {
                return staffManag.Paiements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public Paiement Update(Paiement paiement)
        {
            try
            {
                mainPaiement = paiement;
                staffManag.SaveChanges();
                return paiement;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification d'employé '{employee1.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
