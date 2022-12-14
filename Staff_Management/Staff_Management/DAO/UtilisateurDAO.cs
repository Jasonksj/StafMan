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
    public class UtilisateurDAO
    {
        StafManEntities staffManag;

        Utilisateur utilisateur;

        public UtilisateurDAO()
        {
            staffManag = new StafManEntities();
            utilisateur = new Utilisateur();
        }

        public Utilisateur Save(Utilisateur utilisateur)
        {
            try
            {
                this.utilisateur = utilisateur;
                staffManag.Utilisateurs.Add(this.utilisateur);
                staffManag.SaveChanges();
                return this.utilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                   (
                       $"Enregistrement impossible de l'utilisateur '{this.utilisateur.NomUtilisateur}'!\nErreur : {ex.Message}",
                       "Echec",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error
                   );
                return null;
            }

        }
        public int Delete(int IdUtilisateur)
        {
            try
            {
                this.utilisateur = staffManag.Utilisateurs.FirstOrDefault
                    (
                        utilisateur => utilisateur.IdUtilisateur == IdUtilisateur
                    );
                staffManag.Utilisateurs.Remove(this.utilisateur);
                staffManag.SaveChanges();
                return this.utilisateur.IdUtilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"suppression impossible de la mission ! '{this.utilisateur.NomUtilisateur}'\nErreur : {ex.Message}",
                        "Erreur",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }
        public bool Exists(int IdUtilisateur)
        {
            try
            {
                return staffManag.Utilisateurs.SingleOrDefault
                (
                    utilisateur => utilisateur.IdUtilisateur == IdUtilisateur

                ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }
        public List<Utilisateur> FindAll()
        {
            try
            {
                return staffManag.Utilisateurs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            try
            {
                this.utilisateur = utilisateur;
                staffManag.Utilisateurs.AddOrUpdate(this.utilisateur);
                staffManag.SaveChanges();
                return this.utilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la mission ! '{this.utilisateur.NomUtilisateur}'\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
