using Microsoft.Win32;
using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Staff_Management.Services
{
    public class UtilisateurServices
    {
        UtilisateurDAO utilisateurDao;

        EmployeeService employeeService;

        public UtilisateurServices()
        {
            utilisateurDao = new UtilisateurDAO();
            employeeService = new EmployeeService();
        }

        public List<Utilisateur> FindAll()
        {
            return utilisateurDao.FindAll();
        }

        public Utilisateur Find(string name, string password)
        {
            try
            {
                return FindAll().Find
                    (
                        utilisateur => utilisateur.NomUtilisateur == name &&
                                       utilisateur.MotDePasse == password
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            return utilisateurDao.Exists(id);
        }

        public bool Exists(string name, string password)
        {
            try
            {
                return FindAll().FirstOrDefault
                    (
                        utilisateur => utilisateur.NomUtilisateur == name &&
                                       utilisateur.MotDePasse == password
                    ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Utilisateur Save(Utilisateur utilisateur)
        {
            bool exists = Exists(utilisateur.NomUtilisateur, utilisateur.MotDePasse);
            bool isMatched = employeeService.Exists(utilisateur.IdUtilisateur);

            try
            {
                if (!exists && isMatched )
                    return utilisateurDao.Save(utilisateur);
                else 
                {
                    if (!isMatched)
                    {

                        System.Windows.MessageBox.Show
                            (
                                $"l'utilisateur '{utilisateur.NomUtilisateur}' n'a pas de correspondance avec un employe !",
                                "Echec",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error
                            );
                    }
                    if (exists)
                    {
                        System.Windows.MessageBox.Show
                            (
                                $"l'utilisateur '{utilisateur.NomUtilisateur}' existe déjà !",
                                "Echec",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error
                            );
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return utilisateurDao.Delete(id);
                else
                {
                    System.Windows.MessageBox.Show
                        (
                            "Cet utilisateur n'existe pas !",
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

        public Utilisateur Update(Utilisateur utilisateur)
        {
            try
            {
                bool hasThisUnameAndThisPwdHere =  Exists(utilisateur.NomUtilisateur, utilisateur.MotDePasse);
                bool hasThisIdHere = Exists(utilisateur.IdUtilisateur);
                if (hasThisIdHere && !hasThisUnameAndThisPwdHere)
                    return utilisateurDao.Update(utilisateur);
                else if (!hasThisIdHere)
                    System.Windows.MessageBox.Show
                        (
                            $"Cet Utilisateur n'existe pas !",
                            "Echec",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                else if (hasThisUnameAndThisPwdHere)
                    System.Windows.MessageBox.Show
                        (
                            $"L'utilisateur '{utilisateur.NomUtilisateur}' existe déjà !",
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

        public List<Utilisateur> FilterByUsername(string username)
        {
            try
            {
                return FindAll().FindAll
                    (
                        utilisateur => utilisateur.NomUtilisateur.IndexOf
                        (
                            username,
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Employee FindCorrespondingEmployee(Utilisateur utilisateur)
        {
            try
            {
                return employeeService.FindAll().Find
                    (
                        employee => employee.Id == utilisateur.IdUtilisateur
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
