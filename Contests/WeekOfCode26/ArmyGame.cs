using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode26
{
    // https://www.hackerrank.com/contests/w26/challenges/game-with-cells
    class ArmyGame
    {
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            if ((n % 2) == 1) n++;
            if ((m % 2) == 1) m++;
            int numPackages = (n * m) / 4;
            Console.WriteLine(numPackages);
        }
    }
}
