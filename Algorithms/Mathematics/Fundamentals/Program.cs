using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            LeonardosPrimes.Run();
        }
    }

    // https://www.hackerrank.com/challenges/leonardo-and-prime
    class LeonardosPrimes
    {
        public static void Run()
        {
            int[] firstPrimes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67 };
            long[] maxUnique = new long[firstPrimes.Length];
            long mult = 1;
            for (var i = 0; i < maxUnique.Length; i++)
            {
                mult *= firstPrimes[i];
                if (mult < 0)
                {
                    // overflow
                    maxUnique[i] = long.MaxValue;
                    mult = -1;
                }
                else
                {
                    maxUnique[i] = mult - 1;
                }
            }

            int q = int.Parse(Console.ReadLine());
            for (var i = 0; i < q; i++)
            {
                long l = long.Parse(Console.ReadLine());
                for (int j = 0; j < maxUnique.Length; j++)
                {
                    if (l <= maxUnique[j])
                    {
                        Console.WriteLine(j);
                        break;
                    }
                }
            }
        }
    }
}
