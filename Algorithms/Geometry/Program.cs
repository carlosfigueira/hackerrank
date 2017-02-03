using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            SherlockAndCounting.Run();
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-counting
    // Easy, 20
    class SherlockAndCounting
    {
        static class Console
        {
            static bool useConsole = false;
            static bool initialized = false;
            static string fileName = @"C:\temp\deleteme\input00.txt";
            static int lineIndex;
            static string[] lines;
            public static string ReadLine()
            {
                if (useConsole)
                {
                    return System.Console.ReadLine();
                }
                else
                {
                    if (!initialized)
                    {
                        initialized = true;
                        lineIndex = 0;
                        lines = File.ReadAllLines(fileName);
                    }

                    return lines[lineIndex++];
                }
            }
        }

        public static void Run()
        {
            int q = int.Parse(Console.ReadLine());
            for (int iq = 0; iq < q; iq++)
            {
                int[] temp = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                long n = temp[0];
                long k = temp[1];
                long nk = n * k;

                // i * (n - i) - nk <= 0
                // -i^2 + in - nk <= 0
                // Roots: 
                long delta = n * n - 4 * nk;
                long result = n - 1;
                if (delta > 0)
                {
                    long root1 = (long)Math.Ceiling((n - Math.Sqrt(delta)) / 2);
                    while (root1 * (n - root1) > nk)
                    {
                        root1--;
                    }

                    result = root1;

                    long root2 = (long)Math.Floor((n + Math.Sqrt(delta)) / 2);
                    while (root2 * (n - root2) > nk)
                    {
                        root2++;
                    }

                    result += (n - root2);
                }
                //Console.WriteLine("{0} - {1} - {2}", delta, root1, root2);
                System.Console.WriteLine(result);
            }
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-planes
    // Easy, 20
    class SherlockAndPlanes
    {
        public static void Run()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                Point a = Point.ReadFromConsole();
                Point b = Point.ReadFromConsole();
                Point c = Point.ReadFromConsole();
                Point d = Point.ReadFromConsole();

                Point abVector = a.Subtract(b);
                Point acVector = a.Subtract(c);
                Point adVector = a.Subtract(d);
                Point normalVector = abVector.CrossProduct(acVector);
                int crossProduct = normalVector.DotProduct(adVector);
                Console.WriteLine(crossProduct == 0 ? "YES" : "NO");
            }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public static Point ReadFromConsole()
            {
                int[] coords = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                return new Point
                {
                    X = coords[0],
                    Y = coords[1],
                    Z = coords[2]
                };
            }

            public Point Subtract(Point other)
            {
                return new Point
                {
                    X = this.X - other.X,
                    Y = this.Y - other.Y,
                    Z = this.Z - other.Z
                };
            }

            public Point CrossProduct(Point other)
            {
                return new Point
                {
                    X = this.Y * other.Z - this.Z * other.Y,
                    Y = this.Z * other.X - this.X * other.Z,
                    Z = this.X * other.Y - this.Y * other.X
                };
            }

            public int DotProduct(Point other)
            {
                return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
            }
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
