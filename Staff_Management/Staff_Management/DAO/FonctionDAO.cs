using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.DAO
{
    public class FonctionDAO
    {
        StafManEntities stafMan;

        Fonction fonction;

        public FonctionDAO()
        {
            stafMan = new StafManEntities();
            fonction = new Fonction();
        }

        public Fonction Save(Fonction fonction)
        {
            try
            {
                this.fonction = fonction;
                stafMan.Fonctions.Add(this.fonction);
                stafMan.SaveChanges();
                return this.fonction;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement impossible de la fonction '{this.fonction.Nom}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }

        public int Delete(int id)
        {
            try
            {
                fonction = stafMan.Fonctions.FirstOrDefault
                    (
                        fonction => fonction.IdFonction == id
                    );
                stafMan.Fonctions.Remove(fonction);
                stafMan.SaveChanges();
                return fonction.IdFonction;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Suppression impossible de la fonction '{this.fonction.Nom}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return -1;
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return stafMan.Fonctions.SingleOrDefault(fonction => fonction.IdFonction == id) != null;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Fonction> FindAll()
        {
            try
            {
                return stafMan.Fonctions.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Fonction Update(Fonction fonction)
        {
            try
            {
                this.fonction = fonction;
                stafMan.Fonctions.AddOrUpdate(this.fonction);
                stafMan.SaveChanges();
                return this.fonction;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la fonction '{this.fonction.Nom}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
