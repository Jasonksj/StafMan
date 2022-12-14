using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Services
{
    public class FonctionServices
    {
        FonctionDAO fonctionDAO;

        public FonctionServices()
        {
            fonctionDAO = new FonctionDAO();
        }

        public bool Exists(int id)
        {
            return fonctionDAO.Exists(id);
        }

        public bool Exists(string name)
        {
            try
            {
                List<Fonction> fonctions = FindAll();
                List<Fonction> foundFonctions = fonctions.FindAll
                    (
                        fonction => fonction.Nom == name
                    );

                return foundFonctions.Count > 0;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
        public List<Fonction> FindAll()
        {
            return fonctionDAO.FindAll();
        }

        public Fonction FindByName(string name)
        {
            List<Fonction> fonctions = FindAll();
            return fonctions.Find(fonction => fonction.Nom == name);
        }

        public Fonction FindById(int id)
        {
            try
            {
                return FindAll().Find(fonction => fonction.IdFonction == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Fonction Save(Fonction fonction)
        {
            try
            {
                if (!Exists(fonction.Nom))
                    return fonctionDAO.Save(fonction);
                else
                {
                    MessageBox.Show
                        (
                            $"La fonction '{fonction.Nom} existe déjà !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public List<Fonction> FilterByName(string name)
        {
            try
            {
                return FindAll().Where
                (
                    fonction => fonction.Nom.IndexOf
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

        public Fonction Update(Fonction fonction)
        {
            try
            {
                bool hasThisIdHere = Exists(fonction.IdFonction);
                bool hasThisNameHere = Exists(fonction.Nom);
                if (hasThisIdHere && !hasThisNameHere)
                    return fonctionDAO.Update(fonction);
                else if (!hasThisIdHere)
                {
                    MessageBox.Show
                        (
                            $"Cette fonction n'existe pas !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
                else if (hasThisNameHere)
                {
                    MessageBox.Show
                        (
                            $"La fonction '{fonction.Nom}' existe déjà !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
                return null;
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
                    return fonctionDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            $"Cette fonction n'existe pas !",
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
