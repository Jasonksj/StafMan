using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.DAO
{
    public class CongesDAO
    {
        StafManEntities staffManag;

        Conge conge;
        Employee employee1;

        public CongesDAO()
        {
            staffManag = new StafManEntities();
            conge = new Conge();
            employee1 = new Employee();
        }

        public Conge Save(Conge conges)
        {
            try
            {
                conge = conges;
                staffManag.Conges.Add(conges);
                staffManag.SaveChanges();
                return conge;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Demande de l'employé '{employee1.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idConges)
        {
            try
            {
                conge = staffManag.Conges.FirstOrDefault
                (
                    conge => conge.IdConges == idConges
                );
                staffManag.Conges.Remove(conge);
                staffManag.SaveChanges();
                return conge.IdConges;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                        $"Suppression de la demande de l'employé impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return staffManag.Conges.SingleOrDefault
                    (
                        conge => conge.IdConges == id
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Conge> FindAll()
        {
            try
            {
                return staffManag.Conges.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public Conge Update(Conge conges)
        {
            try
            {
                conge = conges;
                staffManag.Conges.AddOrUpdate(conge);
                staffManag.SaveChanges();
                return conge;
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
