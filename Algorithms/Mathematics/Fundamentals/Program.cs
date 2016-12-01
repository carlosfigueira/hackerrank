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
            StrangeGrid.Run();
        }
    }

    // https://www.hackerrank.com/challenges/strange-grid
    class StrangeGrid
    {
        public static void Run()
        {
            long[] rc = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long r = rc[0];
            long c = rc[1];
            long nonStrangeRow = (r - 1) / 2;
            long n = nonStrangeRow * (c * 2) + (c - 1);
            Console.WriteLine(n);
        }
    }

    // https://www.hackerrank.com/challenges/reverse-game
    class ReversingGame
    {
        public static void Run()
        {
            int T = int.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int[] NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int N = NK[0];
                int K = NK[1];
                for (var i = 0; i < N; i++)
                {
                    if (K >= i)
                    {
                        int windowSize = N - i;
                        int windowIndex = K - i;
                        int windowNewPosition = windowSize - windowIndex - 1;
                        K = windowNewPosition + i;
                    }
                    else
                    {
                        // Won't be reversed anymore
                        break;
                    }
                }

                Console.WriteLine(K);
            }
        }
    }

    // https://www.hackerrank.com/challenges/connecting-towns
    class ConnectingTowns
    {
        public static void Run()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                int[] Routes = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                long TotalRoutes = 1;
                for (int j = 0; j < (N - 1); j++)
                {
                    TotalRoutes *= Routes[j];
                    TotalRoutes = TotalRoutes % 1234567;
                }

                Console.WriteLine(TotalRoutes);
            }
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-moving-tiles
    class SherlockAndMovingTiles
    {
        public static void Run()
        {
            double[] ls1s2 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double L = ls1s2[0];
            double S1 = ls1s2[1];
            double S2 = ls1s2[2];
            double relSpeed = Math.Abs(S1 - S2); // difference of speeds
            double relSpeedX = relSpeed / Math.Sqrt(2); // difference of speeds, X axis
            int Q = int.Parse(Console.ReadLine());
            for (var i = 0; i < Q; i++)
            {
                var qi = double.Parse(Console.ReadLine());

                // Area = (L - t * relSpeedX) ^ 2
                // sqrt(Area) = L - t * relSpeedX
                // t = (L - sqrt(Area)) / relSpeedX
                double t = (L - Math.Sqrt(qi)) / relSpeedX;
                Console.WriteLine(t);
            }
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
