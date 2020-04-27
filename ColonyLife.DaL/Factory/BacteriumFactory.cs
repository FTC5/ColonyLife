using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.DaL.Flyweight;

namespace ColonyLife.DaL.Factory
{
    public class BacteriumFactory
    {
        List<BacteriumType> cache=new List<BacteriumType>();
        public BacteriumType GetBacterium(string kind, int lifeCycle, int chieldCount, int divisionsCount, int tMin, int tMax)
        {
            BacteriumType type = cache.Find(item => item.Kind == kind);
            if (type == null)
            {
                type = new BacteriumType(kind, lifeCycle, chieldCount, divisionsCount, tMin, tMax);
                cache.Add(type);
            }
            return type;
        }
    }
}
