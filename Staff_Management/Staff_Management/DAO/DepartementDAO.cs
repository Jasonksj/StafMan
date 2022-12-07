using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.DAO
{
    public class DepartementDAO
    {
        StafManEntities stafMan;

        Departement departement;


        public DepartementDAO()
        {
            stafMan = new StafManEntities();
            departement = new Departement();
        }

        public Departement Save(Departement departement)
        {
            try
            {
                this.departement = departement;
                stafMan.Departements.Add(this.departement);
                stafMan.SaveChanges();
                return this.departement;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement du departement impossible'{this.departement.Nom}'!\nErreur : {ex.Message}",
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
                departement = stafMan.Departements.FirstOrDefault
                    (
                        departement => departement.IdDept == id
                    );
                stafMan.Departements.Remove(departement);
                stafMan.SaveChanges();
                return departement.IdDept;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Suppression impossible du departement '{this.departement.Nom}'!\nErreur : {ex.Message}",
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
                return stafMan.Departements.SingleOrDefault(departement => departement.IdDept == id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Departement> FindAll()
        {
            try
            {
                return stafMan.Departements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Departement Update(Departement departement)
        {
            try
            {
                this.departement = departement;
                stafMan.SaveChanges();
                return this.departement;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible du departement '{this.departement.Nom}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }

    }
}
