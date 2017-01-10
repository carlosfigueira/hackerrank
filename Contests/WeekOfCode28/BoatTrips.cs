using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode28
{
    class BoatTrips
    {
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int c = Convert.ToInt32(tokens_n[1]);
            int m = Convert.ToInt32(tokens_n[2]);
            string[] p_temp = Console.ReadLine().Split(' ');
            int[] p = Array.ConvertAll(p_temp, Int32.Parse);
            bool canTransport = true;
            for (int i = 0; i < n; i++)
            {
                if (p[i] > (c * m))
                {
                    canTransport = false;
                    break;
                }
            }
            Console.WriteLine(canTransport ? "Yes" : "No");
        }
    }
}
