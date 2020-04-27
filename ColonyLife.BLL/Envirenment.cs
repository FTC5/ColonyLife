using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL;
using ColonyLife.DaL.Factory;
using ColonyLife.DaL.Flyweight;

namespace ColonyLife.BLL
{
    public class ServiceEnvirenment
    {
        private int temperature;
        public void setTemperature(int temperature)
        {
            this.temperature = temperature;
            int length = colonies.Count;
            for (int i = 0; i < length; i++)
            {
                colonies[i].ChangeTemperature(temperature);
                colonyInfo[i].State = colonies[i].State.GetType().Name;
            }
        }
        


        List<BacteriaColony> colonies;
        List<ColonyInfo> colonyInfo;
        BacteriumFactory factory;

        public int Temperature { get => temperature;}

        public ServiceEnvirenment(int temperature=0)
        {
            factory = new BacteriumFactory();
            colonies = new List<BacteriaColony>();
            colonyInfo = new List<ColonyInfo>();
        }
        public bool CheckName(string name)
        {
            int length = colonyInfo.Count;
            for (int i = 0; i < length; i++)
            {
                if (colonyInfo[i].KindName == name)
                {
                    return true;
                }
            }
            return false;
        }
        public List<ColonyInfo> GetInfo()
        {
            return colonyInfo;
        }
        public void AddColony(string kind, int lifeCycle, int chieldCount, int divisionsCount, int tMin, int tMax)
        {
            BacteriumType bacteriumType = factory.GetBacterium(kind, lifeCycle, chieldCount, divisionsCount, tMin, tMax);
            BacteriaColony bacteriaColony = new BacteriaColony(bacteriumType,temperature);
            colonies.Add(bacteriaColony);
            colonyInfo.Add(new ColonyInfo(bacteriaColony.Getkind(), bacteriaColony.GetBacteriumCount(),bacteriaColony.State.GetType().Name));
        }
        public void DeleteColony(int colony)
        {
            colonies.RemoveAt(colony);
            colonyInfo.RemoveAt(colony);
        }
        public void Life()
        {
            int length = colonies.Count;
            for (int i = 0; i < length; i++)
            {
                colonies[i].Life();
                colonyInfo[i].Count = colonies[i].GetBacteriumCount();
            }
        }
    }
}
