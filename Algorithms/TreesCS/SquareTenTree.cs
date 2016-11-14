using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesCS
{
    // https://www.hackerrank.com/challenges/square-ten-tree
    // Examples:
    // 1; 10 ==> 1; 1 1
    //   (1 segment of L1 - [1,10])
    // 42; 1024 => 5; 0 9; 1 5; 2 9; 1 2; 0 4
    //   (9 segments of L0 - [42,42],[43,43],...,[49,49],[50,50])
    //   (5 segments of L1 - [51,60],...,[91,100])
    //   (9 segments of L2 - [101,200],...,[901,1000])
    //   (2 segments of L1 - [1001,1010],[1011,1020])
    //   (4 segments of L0 - [1021,1021],...,[1024,1024])
    class SquareTenTree
    {
        public static void Run()
        {
            int L = int.Parse(Console.ReadLine());
            int R = int.Parse(Console.ReadLine());

            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            int l = L - 1;
            int r = R - 1;
            int levelL = (int)Math.Log10(l == 0 ? 1 : l);
            int levelR = (int)Math.Log10(r == 0 ? 1 : r);
            int[] pow10 = new[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            if (levelL < levelR)
            {
                // Get L to the same level as R first
                for (var i = 0; i <= levelR; i++) { 
                int mod10 = L % 10;
                if (mod10 > 0)
                {
                    result.Add(new KeyValuePair<int, int>(0, 10 - mod10 + 1));
                    L += (10 - mod10 + 1);
                }
            }
        }
    }
}
