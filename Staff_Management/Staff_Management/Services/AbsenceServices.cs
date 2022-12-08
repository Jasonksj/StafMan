using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Staff_Management.DAO;
using Staff_Management.Entities;

namespace Staff_Management.Services
{
    public class AbsenceServices
    {
        AbsenceDAO absenceDAO;

        public AbsenceServices()
        {
            absenceDAO = new AbsenceDAO();
        }

        public List<Absence> FindAll()
        {
            return absenceDAO.FindAll();
        }

        public List<Absence> FilterByLostPercent(float lostPercent)
        {
            try
            {
                return FindAll().FindAll(absence => absence.PourcentagePerte == lostPercent);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(string motif)
        {
            try
            {
                return FindAll().Find
                    (
                        absence => absence.Motif == motif
                    ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            return absenceDAO.Exists(id);
        }

        public Absence Save(Absence absence)
        {
            try
            {
                if (!Exists(absence.Motif))
                    return absenceDAO.Save(absence);
                else
                {
                    MessageBox.Show
                        (
                            $"L'absence ayant pour motif '{absence.Motif}' existe déjà",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Absence> FilterByMotif(string motif)
        {
            try
            {
                return FindAll().FindAll
                    (
                        absence => absence.Motif.IndexOf
                        (
                            motif,
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    );
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
                bool hasThisMotifHere = Exists(absence.Motif);
                bool hasThisIdHere = Exists(absence.IdAbsence);
                if (hasThisIdHere && !hasThisMotifHere)
                    return absenceDAO.Update(absence);
                else if (!hasThisIdHere)
                    MessageBox.Show
                        (
                            $"Ce type d'absence n'existe pas !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                else if (hasThisMotifHere)
                    MessageBox.Show
                        (
                            $"Ce motif d'absence existe déjà !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                return null;
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
                            "Ce type d'absence n'existe pas !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
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
