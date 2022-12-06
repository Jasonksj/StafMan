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
            List<Fonction> fonctions = FindAll();
            List<Fonction> foundFonctions = fonctions.FindAll
                (
                    fonction => fonction.Nom == name
                );

            return foundFonctions.Count > 1;
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
                if (Exists(fonction.IdFonction))
                    return fonctionDAO.Update(fonction);
                else
                {
                    MessageBox.Show
                        (
                            $"La fonction '{fonction.Nom} n'existe pas !",
                            "Echec",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
            }
        }
    }
}
