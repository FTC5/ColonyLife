using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;
using ColonyLife.DaL.Interface;

namespace ColonyLife.DaL
{
    public class Bacterium
    {
        int age;
        private BacteriumType type;
        public Bacterium(BacteriumType type)
        {
            Type = type;
            age = 0;
        }

        public BacteriumType Type { get => type; private set => type = value; }
        public Bacterium[] Division(IBacteriumState state)
        {
            return state.Division(age,type);
        }
        public bool Life(IBacteriumState state)
        {
            return state.Life(age,type.LifeCycle);
        }
        public void Growth(IBacteriumState state)
        {
            age = state.Growth(age);
        }
    }
}
