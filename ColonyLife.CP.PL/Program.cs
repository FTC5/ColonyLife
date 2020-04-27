using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColonyLife.BLL;

namespace ColonyLife.CP.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            ColonyLife.BLL.ServiceEnvirenment envirenment= new ColonyLife.BLL.ServiceEnvirenment();
            Menu menu = new Menu(envirenment);
            menu.MainMenu();
        }
    }
}
