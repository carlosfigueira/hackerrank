using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            //UtopianTree.Run();
            SherlockAndSquares.Run();
        }
    }

    class MinMax
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i =0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            numbers.Sort();
            int best = int.MaxValue;
            for (int i = 0; i < n - k + 1; i++)
            {
                int current = numbers[i + k - 1] - numbers[i];
                if (best > current) best = current;
            }

            Console.WriteLine(best);
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-squares
    class SherlockAndSquares
    {
        public static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int[] ab = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                int a = ab[0];
                int b = ab[1];
                int sra = (int)Math.Sqrt(a);
                int first = (sra * sra == a) ? sra : sra + 1;

                int srb = (int)Math.Ceiling(Math.Sqrt(b));
                int last = (srb * srb == b) ? srb : srb - 1;
                Console.WriteLine(last - first + 1);
            }
        }
    }

    // https://www.hackerrank.com/challenges/utopian-tree
    class UtopianTree
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int pow = (n + 1) / 2;
                long exp = 2L << pow;
                long h = exp - ((n % 2) == 1 ? 2 : 1);

                //long h = 1;
                //for (int i = 0; i < n; i++)
                //{
                //    if ((i % 2) == 0)
                //    {
                //        h *= 2;
                //    }
                //    else
                //    {
                //        h += 1;
                //    }
                //}

                Console.WriteLine(h);
            }
        }
    }
}
