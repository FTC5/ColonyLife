using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyLife.DaL.Flyweight
{
    public class BacteriumType
    {
        string kind;
        int lifeCycle;
        int chieldCount;
        int divisionsCount;
        int tMin;
        int tMax;

        public BacteriumType(string kind, int lifeCycle, int chieldCount, int divisionsCount, int tMin, int tMax)
        {
            this.kind = kind;
            this.lifeCycle = lifeCycle;
            this.chieldCount = chieldCount;
            this.divisionsCount = divisionsCount;
            this.tMin = tMin;
            this.tMax = tMax;
        }

        public int TMin { get => tMin;}
        public int TMax { get => tMax;}
        public int DivisionsCount { get => divisionsCount;}
        public int ChieldCount { get => chieldCount;}
        public int LifeCycle { get => lifeCycle;}
        public string Kind { get => kind;}
    }
}
