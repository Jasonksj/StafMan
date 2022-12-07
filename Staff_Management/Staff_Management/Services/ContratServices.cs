using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.Services
{
    public class ContratServices
    {
        ContratDAO contratDAO;

        MissionServices missionServices;

        public ContratServices()
        {
            contratDAO = new ContratDAO();
            missionServices = new MissionServices();
        }

        public List<Contrat> FindAll()
        {
            return contratDAO.FindAll();
        }

        public bool Exists(string name, int idEmploye, DateTime dateDebut)
        {
            try
            {
                return contratDAO.Exists(idEmploye, dateDebut, name);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Contrat Save(Contrat contrat)
        {
            try
            {
                if (!Exists(contrat.Titre, contrat.IdEmployee, contrat.DateDebutContrat))
                    return contratDAO.Update(contrat);
                else
                {
                    MessageBox.Show
                        (
                            $"Le contrat '{contrat.Titre}' existe déjà pour l'employé {contrat.Employee.Nom} !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Contrat> FilterByName(string name)
        {
            try
            {
                return FindAll().Where
                (
                    contrat => contrat.Titre.IndexOf
                    (
                        name,
                        StringComparison.CurrentCultureIgnoreCase
                    ) != -1
                ).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Delete(int idEmployee, DateTime dateDebut, string title)
        {
            try
            {
                if (Exists(title, idEmployee, dateDebut))
                    return contratDAO.Delete(idEmployee, dateDebut, title);
                else
                {
                    MessageBox.Show
                        (
                            $"Le contrat '{title}' n'existe pas !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                    return -1;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Contrat Update(Contrat contrat)
        {
            try
            {
                if (Exists(contrat.Titre, contrat.IdEmployee, contrat.DateDebutContrat))
                    return contratDAO.Update(contrat);
                else
                {
                    MessageBox.Show
                        (
                            $"Le contrat '{contrat.Titre}' n'existe pas pour l'employé {contrat.Employee.Nom}!",
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

        public Contrat Find(string title, int idEmploye, DateTime dateDebut)
        {
            try
            {
                return FindAll().Find
                (
                    contrat => contrat.Titre == title &&
                               contrat.IdEmployee == idEmploye &&
                               contrat.DateDebutContrat == dateDebut
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Mission> GetMissionList(Contrat contrat)
        {
            try
            {
                return missionServices.FindAll().FindAll
                    (
                        mission => mission.IdEmployee == contrat.IdEmployee
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
