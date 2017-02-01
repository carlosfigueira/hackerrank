using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // https://www.hackerrank.com/challenges/rectangular-game
    // Easy, 20
    class RectangularGame
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int maxA = int.MaxValue;
            int maxB = int.MaxValue;
            for (int i=0;i< n; i++)
            {
                int[] ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                maxA = Math.Min(ab[0], maxA);
                maxB = Math.Min(ab[1], maxB);
            }

            long cells = maxA;
            cells *= maxB;
            Console.WriteLine(cells);
        }
    }

    // https://www.hackerrank.com/challenges/points-on-a-line
    // Easy, 10
    class PointsOnALine
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] X = new int[n];
            int[] Y = new int[n];
            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                X[a0] = Convert.ToInt32(tokens_x[0]);
                Y[a0] = Convert.ToInt32(tokens_x[1]);
            }
            bool isVerticalLine = true;
            for (int i = 1; i < n; i++)
            {
                if (X[i] != X[0])
                {
                    isVerticalLine = false;
                    break;
                }
            }
            bool isHorizontalLine = true;
            for (int i = 1; i < n; i++)
            {
                if (Y[i] != Y[0])
                {
                    isHorizontalLine = false;
                    break;
                }
            }
            Console.WriteLine((isVerticalLine || isHorizontalLine) ? "YES" : "NO");
        }
    }
}
