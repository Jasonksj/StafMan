using Staff_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.DAO
{
    public class MissionDAO
    {
        StafManEntities stafMan;

        Mission mission;

        public MissionDAO()
        {
            stafMan = new StafManEntities();
            mission = new Mission();
        }

        public Mission Save(Mission mission)
        {
            try
            {
                this.mission = mission;
                stafMan.Missions.Add(this.mission);
                stafMan.SaveChanges();
                return this.mission;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement impossible du contrat '{this.mission.Intitule}'!\nErreur : {ex.Message}",
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
                mission = stafMan.Missions.FirstOrDefault
                    (
                        mission => mission.IdMission == id
                    );
                stafMan.Missions.Remove(mission);
                stafMan.SaveChanges();
                return mission.IdMission;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Suppression impossible de le contrat '{this.mission.Intitule}'!\nErreur : {ex.Message}",
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
                return stafMan.Missions.SingleOrDefault
                    (
                        mission => mission.IdMission == id
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Mission> FindAll()
        {
            try
            {
                return stafMan.Missions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Mission Update(Mission mission)
        {
            try
            {
                this.mission = mission;
                stafMan.Missions.AddOrUpdate(this.mission);
                stafMan.SaveChanges();
                return this.mission;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la fonction '{this.mission.Intitule}'!\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
