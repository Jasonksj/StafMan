using Staff_Management.DAO;
using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Staff_Management.Services
{
    public class MissionServices
    {

        MissionDAO missionDAO;

        public MissionServices()
        {
            missionDAO = new MissionDAO();
        }

        public List<Mission> FindAll()
        {
            return missionDAO.FindAll();
        }

        public Mission Save(Mission mission)
        {
            try
            {
                return missionDAO.Save(mission);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur " + ex.Message);
            }
        }

        public List<Mission> FilterByName(string name)
        {
            try
            {
                return FindAll().Where
                    (
                        mission => mission.Intitule.IndexOf
                        (
                            name,
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    ).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur " + ex.Message);
            }
        }

        public Mission FindByName(string name)
        {
            try
            {
                return FindAll().Find
                    (
                        mission => mission.Intitule == name
                    );
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            return missionDAO.Exists(id);
        }

        public int Delete(int id)
        {
            try
            {
                if (Exists(id))
                    return missionDAO.Delete(id);
                else
                {
                    MessageBox.Show
                        (
                            "Cette mission n'existe pas !",
                            "Erreur",
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

        public Mission Update(Mission mission)
        {
            try
            {
                if (Exists(mission.IdMission))
                    return missionDAO.Update(mission);
                else
                {
                    MessageBox.Show
                        (
                            $"La mission '{mission.Intitule} n'existe pas !",
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
    }
}
