using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode29
{
    class AlmostIntegerRockGarden
    {
        public static void Run()
        {
            List<Distance> candidates = new List<Distance>
            {
                new Distance(1, 11, 2),
                new Distance(2, 12, 1),
                new Distance(3, 10, 1),
                new Distance(3, 12, 1),
                new Distance(4, 5, 1),
                new Distance(6, 6, 1),
                new Distance(6, 9, 1),
                new Distance(7, 11, 1),
                new Distance(7, 12, 1),
                new Distance(4, 12, 2)
            };

            string[] tokens_x = Console.ReadLine().Split(' ');
            int x = Convert.ToInt32(tokens_x[0]);
            int y = Convert.ToInt32(tokens_x[1]);
            int distance = x * x + y * y;
            int found = -1;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Value == distance)
                {
                    found = i;
                    candidates[i].Quantity--;
                    break;
                }
            }

            if (found < 0)
            {
                // Will fail
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine("{0} {0}", i);
                }
            }
            else
            {
                for (int i = 0; i < candidates.Count; i++)
                {
                    Distance candidate = candidates[i];
                    for (int j = 0; j < candidate.Quantity; j++)
                    {
                        Console.WriteLine("{0} {1}{2}", candidate.X, j == 0 ? "" : "-", candidate.Y);
                    }
                }
            }
        }

        class Distance
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Quantity { get; set; }
            public int Value
            {
                get { return X * X + Y * Y; }
            }
            public Distance(int x, int y, int quantity)
            {
                this.X = x;
                this.Y = y;
                this.Quantity = quantity;
            }
        }
    }
}
