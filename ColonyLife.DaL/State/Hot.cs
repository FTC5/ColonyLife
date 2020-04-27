using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;
using ColonyLife.DaL.Interface;

namespace ColonyLife.DaL.State
{
    class Hot : IBacteriumState
    {
        public Bacterium[] Division(int age, BacteriumType type)
        {
            Bacterium[] bacteria = new Bacterium[type.ChieldCount + type.ChieldCount];
            for (int i = 0; i < bacteria.Length; i++)
            {
                bacteria[i] = new Bacterium(type);
            }
            return bacteria;
        }

        public int Growth(int age)
        {
            age += 2;
            return age;
        }

        public bool Life(int age, int lifeCycle)
        {
            if (age == lifeCycle / 2 || age >= lifeCycle)
            {
                return false;
            }
            return true;
        }
    }
}
