using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;
using ColonyLife.DaL.Interface;

namespace ColonyLife.DaL.State
{
    class Frozen : IBacteriumState
    {
        public Bacterium[] Division(int age, BacteriumType type)
        {
            return null;
        }

        public int Growth(int age)
        {
            return age;
        }

        public bool Life(int age, int lifeCycle)
        {
            return true;
        }
    }
}
