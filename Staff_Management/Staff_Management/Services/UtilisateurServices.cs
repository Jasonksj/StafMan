using Microsoft.Win32;
using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.Services
{
    public class UtilisateurServices
    {
        UtilisateurDAO utilisateurDao;

        public UtilisateurServices()
        {
            utilisateurDao = new UtilisateurDAO();
        }

        public List<Utilisateur> FindAll()
        {
            return utilisateurDao.FindAll();
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
            try
            {
                if (!Exists(utilisateur.NomUtilisateur, utilisateur.MotDePasse))
                    return utilisateurDao.Save(utilisateur);
                else
                {
                    MessageBox.Show
                        (
                            $"l'utilisateur '{utilisateur.NomUtilisateur}' existe déjà !",
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

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return utilisateurDao.Delete(id);
                else
                {
                    MessageBox.Show
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
                if (Exists(utilisateur.IdUtilisateur))
                    return utilisateurDao.Update(utilisateur);
                else
                {
                    MessageBox.Show
                        (
                            $"L'utilisateur '{utilisateur.NomUtilisateur}' n'existe pas !",
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

        public Utilisateur FindByEmployee(Employee employee)
        {
            try
            {
                return FindAll().Find
                    (
                        utilisateur => utilisateur.IdUtilisateur == employee.Id
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
