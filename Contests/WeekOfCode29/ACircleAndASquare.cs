//#define TEST

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode29
{
    class ACircleAndASquare
    {
        const double EPSILON = 0.0001;

        public static void Run()
        {
#if !TEST
            string[] tokens_w = Console.ReadLine().Split(' ');
            int w = Convert.ToInt32(tokens_w[0]);
            int h = Convert.ToInt32(tokens_w[1]);
            string[] tokens_circleX = Console.ReadLine().Split(' ');
            int circleX = Convert.ToInt32(tokens_circleX[0]);
            int circleY = Convert.ToInt32(tokens_circleX[1]);
            int r = Convert.ToInt32(tokens_circleX[2]);
            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int y1 = Convert.ToInt32(tokens_x1[1]);
            int x3 = Convert.ToInt32(tokens_x1[2]);
            int y3 = Convert.ToInt32(tokens_x1[3]);
#else
            int x1 = 2, y1 = 6, x3 = 8, y3 = 4;
            int circleX = 10, circleY = 10, r = 1;
            int w = 20, h = 16;
            //int x1 = 16, y1 = 14, x3 = 8, y3 = 14;
            //int circleX = 9, circleY = 6, r = 5;
            //int w = 20, h = 16;
#endif

            char[,] grid = new char[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    grid[i, j] = '.';
                }
            }

            MarkPointsInsideCircle(grid, w, h, circleX, circleY, r);
            MarkPointsInsideSquare(grid, w, h, x1, y1, x3, y3);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void MarkPointsInsideSquare(char[,] grid, int w, int h, int x1, int y1, int x3, int y3)
        {
            double x2 = (x1 + x3 + y1 - y3) / 2.0;
            double y2 = (x3 - x1 + y1 + y3) / 2.0;
            double x4 = (x1 + x3 + y3 - y1) / 2.0;
            double y4 = (x1 - x3 + y1 + y3) / 2.0;

            double xmin = Math.Min(x1, Math.Min(x2, Math.Min(x3, x4)));
            double xmax = Math.Max(x1, Math.Max(x2, Math.Max(x3, x4)));
            double ymin = Math.Min(y1, Math.Min(y2, Math.Min(y3, y4)));
            double ymax = Math.Max(y1, Math.Max(y2, Math.Max(y3, y4)));

            for (int i = 0; i < h; i++)
            {
                if (i < ymin - EPSILON) continue;
                if (i > ymax + EPSILON) continue;
                for (int j = 0; j < w; j++)
                {
                    if (j < xmin - EPSILON) continue;
                    if (j > xmax + EPSILON) continue;
                    if (IsCollinear(j, i, x1, y1, x2, y2) ||
                        IsCollinear(j, i, x2, y2, x3, y3) ||
                        IsCollinear(j, i, x3, y3, x4, y4) ||
                        IsCollinear(j, i, x4, y4, x1, y1))
                    {
                        grid[i, j] = '#';
                    }
                    else if (IsInside(j, i, x1, y1, x2, y2, x3, y3, x4, y4))
                    {
                        grid[i, j] = '#';
                    }
                }
            }
        }

        private static bool IsInside(int x, int y, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            bool sign1 = Sign(x, y, x1, y1, x2, y2) > 0;
            bool sign2 = Sign(x, y, x2, y2, x3, y3) > 0;
            bool sign3 = Sign(x, y, x3, y3, x4, y4) > 0;
            bool sign4 = Sign(x, y, x4, y4, x1, y1) > 0;
            return (sign1 == sign2) && (sign2 == sign3) && (sign3 == sign4);
        }

        private static double Sign(double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            return (p1x - p3x) * (p2y - p3y) - (p2x - p3x) * (p1y - p3y);
        }

        static bool IsCollinear(int x, int y, double x1, double y1, double x2, double y2)
        {
            return Math.Abs(Distance(x1, y1, x, y) + Distance(x, y, x2, y2) - Distance(x1, y1, x2, y2)) < EPSILON;
        }

        static void MarkPointsInsideCircle(char[,] grid, int w, int h, int circleX, int circleY, int r)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    double dist = Distance(j, i, circleX, circleY);
                    if (dist - r < EPSILON)
                    {
                        grid[i, j] = '#';
                    }
                }
            }
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
}
