using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Copy("LaptopBatteryLife_trainingdata.txt", "trainingdata.txt");
            LaptopBatteryLife.Run();
        }
    }
}
