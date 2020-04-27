using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;
using ColonyLife.DaL.Interface;
using ColonyLife.DaL.State;

namespace ColonyLife.DaL.Factory
{
    public class BacteriaColony
    {
        List<Bacterium> bacteria = new List<Bacterium>();
        BacteriumType type;
        IBacteriumState state;
        int maxCount = 500000;

        public IBacteriumState State { get => state;}
        public int MaxCount { get => maxCount; set => maxCount = value; }

        public BacteriaColony(BacteriumType type, int temperature)
        {
            this.type = type;
            ChangeTemperature(temperature);
            bacteria.Add(new Bacterium(this.type));
        }
        public int GetBacteriumCount()
        {
            int count=bacteria.Count;
            return count;
        }
        public string Getkind()
        {
            return type.Kind;
        }
        public void Life()
        {
            int count = bacteria.Count;
            Bacterium[] buff;
            void BcateriaLife()
            {
                count -= 1;
                bacteria[count].Growth(state);
                buff = bacteria[count].Division(state);
                if (buff != null)
                {
                    bacteria.AddRange(buff);
                }
                if (!bacteria[count].Life(state))
                {
                    bacteria.RemoveAt(count);
                }
            }
            
            if(state is Burned)
            {
                while (count != 0)
                {
                    BcateriaLife();
                }
            }
            else
            {
                while (count != 0)
                {
                    if (maxCount < bacteria.Count)
                    {
                        return;
                    }
                    BcateriaLife();
                }
            }
            
        }
        public void ChangeTemperature(int temperature)
        {
            if (temperature > type.TMax)
            {
                state = new Burned();
            }else if (temperature < type.TMin)
            {
                state = new Frozen(); 
            }else if(temperature> type.TMax - 4)
            {
                state = new Hot();
            }else if(temperature < type.TMin + 4)
            {
                state = new Supercooled();
            }
            else
            {
                state = new Normal();
            }
        }      
    }
}
