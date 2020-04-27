using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyLife.BLL
{
    public class ColonyInfo
    {
        string kindName;
        int count;
        string state;

        public ColonyInfo(string kindName, int count, string state)
        {
            this.kindName = kindName;
            this.count = count;
            this.state = state;
        }

        public string KindName { get => kindName; set => kindName = value; }
        public int Count { get => count; set => count = value; }
        public string State { get => state; set => state = value; }

        public override string ToString()
        {
            return KindName + " : " + count+"; State : "+state;
        }
    }
}
