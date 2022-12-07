using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.DAO
{
    public class AbsenceDAO
    {
        StafManEntities stafMan;

        Absence absence;

        public AbsenceDAO()
        {
            stafMan = new StafManEntities();
            absence = new Absence();
        }

        public Absence Save(Absence absence)
        {
            try
            {
                this.absence = absence;
                stafMan.Absences.Add(this.absence);
                stafMan.SaveChanges();
                return this.absence;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement impossible de la demande !\nErreur : {ex.Message}",
                        "Erreur",
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
                absence = stafMan.Absences.FirstOrDefault
                    (
                        absence => absence.IdAbsence == id
                    );
                stafMan.Absences.Remove(absence);
                stafMan.SaveChanges();
                return absence.IdAbsence;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Suppression impossible de la demande!\nErreur : {ex.Message}",
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
                return stafMan.Absences.SingleOrDefault
                    (
                        absence => absence.IdAbsence == id
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Absence> FindAll()
        {
            try
            {
                return stafMan.Absences.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Absence Update(Absence absence)
        {
            try
            {
                this.absence = absence;
                stafMan.SaveChanges();
                return this.absence;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
