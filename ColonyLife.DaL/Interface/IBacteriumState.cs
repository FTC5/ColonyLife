using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;

namespace ColonyLife.DaL.Interface
{
    public interface IBacteriumState
    {
        Bacterium[] Division(int age, BacteriumType type);
        int Growth(int age);
        bool Life(int age, int lifeCycle);
    }
}
