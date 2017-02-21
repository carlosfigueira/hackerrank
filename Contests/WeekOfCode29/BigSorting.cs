using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode29
{
    class BigSorting
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            Array.Sort(numbers, (n1, n2) =>
            {
                if (n1.Length != n2.Length)
                {
                    return n1.Length - n2.Length;
                }

                for (int i = 0; i < n1.Length; i++)
                {
                    if (n1[i] != n2[i])
                    {
                        return (n1[i] - n2[i]);
                    }
                }

                return 0;
            });

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
