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
    public class CongesServices
    {
        CongesDAO congesDAO;

        public CongesServices()
        {
            congesDAO = new CongesDAO();
        }

        public List<Conge> FindAll()
        {
            return congesDAO.FindAll();
        }

        public List<Conge> FilterAllByStartDate(DateTime startDate)
        {
            try
            {
                return FindAll().FindAll(conge => conge.DateDebut == startDate);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Conge> FilterAllByEndDate(DateTime endDate)
        {
            try
            {
                return FindAll().FindAll(conge => conge.DateFin == endDate);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Conge> FilterByPercentLost(float percentLost)
        {
            try
            {
                return FindAll().FindAll(conge => conge.PourcentageRetrait == percentLost);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Conge FindById(int id)
        {
            try
            {
                return FindAll().Find(conge => conge.IdConges == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            return congesDAO.Exists(id);
        }

        public bool Exists(string justification)
        {
            try
            {
                return FindAll().Find(conge => conge.Justification == justification) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Conge Save(Conge conge)
        {
            try
            {
                if (!Exists(conge.Justification))
                    return congesDAO.Save(conge);
                else
                {
                    MessageBox.Show
                        (
                            $"Un congé présente déjà cette justification !",
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

        public Conge Update(Conge conge)
        {
            try
            {
                bool hasThisJustificationHere = Exists(conge.Justification);
                bool hasThisIdHere = Exists(conge.IdConges);
                if (hasThisIdHere && !hasThisJustificationHere)
                    return congesDAO.Update(conge);
                else if (!hasThisIdHere)
                    MessageBox.Show
                        (
                            $"Le congé modifié n'existe pas !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                else if (hasThisJustificationHere)
                    MessageBox.Show
                        (
                            $"Cette justification existe déjà !",
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
                    return congesDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            $"Ce congé n'existe pas !",
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
        public Conge Findbyjustification (string justification)
        {
            try
            {
                return FindAll().Find(conges => conges.Justification == justification);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
