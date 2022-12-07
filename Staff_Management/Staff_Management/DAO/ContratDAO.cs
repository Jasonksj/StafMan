using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.DAO
{
    public class ContratDAO
    {
        StafManEntities stafMan;

        Contrat contrat;

        public ContratDAO()
        {
            stafMan = new StafManEntities();
            contrat = new Contrat();
        }

        public Contrat Save(Contrat contrat)
        {
            try
            {
                this.contrat = contrat;
                stafMan.Contrats.Add(this.contrat);
                stafMan.SaveChanges();
                return this.contrat;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement impossible du contrat '{this.contrat.Titre}'!\nErreur : {ex.Message}",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }

        public int Delete(int id, DateTime dateDebut)
        {
            try
            {
                contrat = stafMan.Contrats.FirstOrDefault
                    (
                        contrat => contrat.IdEmployee == id &&
                                   contrat.DateDebutContrat == dateDebut
                    );
                stafMan.Contrats.Remove(contrat);
                stafMan.SaveChanges();
                return contrat.IdEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Suppression impossible de le contrat '{this.contrat.Titre}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return -1;
            }
        }

        public bool Exists(int id, DateTime dateDebut)
        {
            try
            {
                return stafMan.Contrats.SingleOrDefault
                    (
                        contrat => contrat.IdEmployee == id &&
                                   contrat.DateDebutContrat == dateDebut
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Contrat> FindAll()
        {
            try
            {
                return stafMan.Contrats.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Contrat Update(Contrat contrat)
        {
            try
            {
                this.contrat = contrat;
                stafMan.SaveChanges();
                return this.contrat;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la fonction '{this.contrat.Titre}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
