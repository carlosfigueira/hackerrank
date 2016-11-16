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
            int levelL = (int)Math.Log10(l == 0 ? 1 : l); //1
            int levelR = (int)Math.Log10(r == 0 ? 1 : r); //3
            int[] pow10 = new[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            int segments;

            // Get L to xxx1
            int d = L;
            int mod = d % 10;
            if (mod != 1)
            {
                segments = (11 - mod) % 10;
                L += segments;
                if (L > R)
                {
                    // Too much
                    L -= segments;
                    result.Add(new KeyValuePair<int, int>(0, R - L + 1));
                    L = R + 1;
                }
                else
                {
                    result.Add(new KeyValuePair<int, int>(0, segments));
                }
            }


            // TODO, continue
            if (L <= R)
            {
                // Get to 01, 001, 0001, 00001, 000001
                for (var i = 1; i < levelR; i++)
                {
                    d = L / pow10[i];
                    mod = d % 10;
                    if (mod != 0)
                    {
                        segments = (10 - mod) % 10;
                        L += segments * pow10[i];
                        result.Add(new KeyValuePair<int, int>(i, segments));
                    }
                }
            }

            if (levelL < levelR)
            {
                // Get L to the same level as R first

            }
            else
            {

            }

            for (var i = levelR; i >= 1; i--)
            {
                var d = (R - L) / pow10[i];
                if (d > 0)
                {
                    result.Add(new KeyValuePair<int, int>(i, d));
                    L += d * pow10[i];
                }
            }

            Console.WriteLine(result.Count);
            for (var i = 0; i < result.Count; i++)
            {
                Console.WriteLine("{0} {1}", result[i].Key, result[i].Value);
            }
        }
    }
}
