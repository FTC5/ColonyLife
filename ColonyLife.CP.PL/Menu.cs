using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ColonyLife.BLL;

namespace ColonyLife.CP.PL
{
    class Menu
    {
        ColonyLife.BLL.ServiceEnvirenment envirenment;
        string choice="";
        int skipInterval = 1;
        public Menu(ServiceEnvirenment envirenment)
        {
            this.envirenment = envirenment;
        }

        public void MainMenu()
        {
            
            while (true)
            {
                GetInfo();
                Console.WriteLine("Create Colony - 1");
                Console.WriteLine("Delate Colony - 2");
                Console.WriteLine("Set skip interval - 3");
                Console.WriteLine("Set temperature - 4");
                Console.WriteLine("Skip time - 5");
                Console.WriteLine("Exit - 6");
                choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        CreateColony();
                        break;
                    case "2":
                        DeleteColony();
                        break;
                    case "3":
                        skipInterval = Check("TickCount=", @"^\d+$");
                        break;
                    case "4":
                        envirenment.setTemperature(Check("Temperature=", @"^[-]?\d+$"));
                        break;
                    case "5":
                        SkipTime();
                        break;
                    case "6":
                        return;
                    default:
                        choice = "";
                        break;
                }
                Console.WriteLine();
            }
        }
        private void GetInfo()
        {
            List<ColonyInfo> colonyInfo;
            Console.WriteLine("\n--------------------\n");
            colonyInfo = envirenment.GetInfo();
            Console.WriteLine("Colonies information");
            if (colonyInfo.Count == 0)
            {
                Console.WriteLine("Colony not found");
            }
            else
            {
                for (int i = 0; i < colonyInfo.Count; i++)
                {
                    Console.WriteLine(colonyInfo[i].ToString());
                }
            }
            Console.WriteLine("\n--------------------\n");
            Console.WriteLine("Temperature = " + envirenment.Temperature.ToString()+" C");
            Console.WriteLine("Skip interval = " + skipInterval.ToString());
            Console.WriteLine("\n--------------------\n");
        }
        private void CreateColony()
        {
            string name = "";
            int lifeCycle = 0;
            int chieldCount = 0;
            int divisionsCount = 0;
            int tmax = 0;
            int tmin = 0;
            Console.Write("Name = ");
            name = Console.ReadLine();
            if (envirenment.CheckName(name))
            {
                Console.Write("Colony already exists. Created copy");
                envirenment.AddColony(name, 0, 0, 0, 0, 0);
                return;
            }
            lifeCycle = Check("Life Cycle =", @"^\d+$");
            chieldCount = Check("Chield Count =", @"^\d+$",1000);
            divisionsCount = Check("Divisions Count =", @"^\d+$",lifeCycle+1);
            tmax = Check("T max =", @"^[-]?\d+$");
            tmin = Check("T min(<"+(tmax-10).ToString()+ ")=", @"^[-]?\d+$",tmax-10);
            envirenment.AddColony(name, lifeCycle, chieldCount, divisionsCount, tmin, tmax);
        }
        private void DeleteColony()
        {
            List<ColonyInfo> colonyInfo= envirenment.GetInfo();
            if (colonyInfo.Count == 0)
            {
                Console.WriteLine("Colony not found");
                return;
            }
            for (int i = 0; i < colonyInfo.Count; i++)
            {
                Console.WriteLine(colonyInfo[i].KindName + " N-"+i);
            }
            choice = Check("Delate colony N=", @"^\d+$", colonyInfo.Count).ToString(); 
            envirenment.DeleteColony(Convert.ToInt32(choice));

        }
        private void SkipTime()
        {
            for (int i = 0; i < skipInterval; i++)
            {
                envirenment.Life();
            }
        }
        private int Check(string output, string pattern, int limitation)
        {
            int input = 0;
            while (true)
            {
                input = Check(output, pattern);
                if (input < limitation)
                {
                    break;
                }
                Console.WriteLine("Wrong input(input<"+limitation+")");
            }
            return input;
        }
        
        private int Check(string output, string pattern)
        {
            string input;
            while (true)
            {
                Console.Write(output+" ");
                input = Console.ReadLine();
                if (RegularCheck(pattern, input))
                {
                    return Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
        private bool RegularCheck(string pattern, string input)
        {
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
