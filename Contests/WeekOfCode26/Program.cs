using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode26
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Twins.Run();
            sw.Stop();
            Console.WriteLine("Ran in {0}", sw.Elapsed);
        }
    }
}
