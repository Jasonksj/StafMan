using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Services
{
    public class AbsenceServices
    {
        AbsenceDAO absenceDAO;

        public AbsenceServices()
        {
            absenceDAO = new AbsenceDAO();
        }

        public bool Exists(int id)
        {
            return absenceDAO.Exists(id);
        }

        public List<Absence> FindAll()
        {
            return absenceDAO.FindAll();
        }

        public Absence Save(Absence absence)
        {
            try
            {
                return absenceDAO.Save(absence);   
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }


        public Absence Update(Absence absence)
        {
            try
            {
                return absenceDAO.Update(absence);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return absenceDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            $"Cette demande d'absence n'existe pas !",
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
