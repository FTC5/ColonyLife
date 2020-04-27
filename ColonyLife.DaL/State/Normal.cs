using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;
using ColonyLife.DaL.Interface;


namespace ColonyLife.DaL.State
{
    class Normal : IBacteriumState
    {
        public Bacterium[] Division(int age, BacteriumType type)
        {
            if (age <= type.DivisionsCount)
            {
                Bacterium[] bacteria = new Bacterium[type.ChieldCount];
                for (int i = 0; i < bacteria.Length; i++)
                {
                    bacteria[i] = new Bacterium(type);
                }
                return bacteria;
            }
            return null;
        }

        public int Growth(int age)
        {
            age += 1;
            return age;
        }
        public bool Life(int age, int lifeCycle)
        {
            if (lifeCycle==age)
            {
                return false;
            }
            return true;
        }
    }
}
