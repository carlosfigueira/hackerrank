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

    // https://www.hackerrank.com/challenges/bon-appetit
    class BonAppetit
    {
        public static void Run()
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = nk[0];
            int k = nk[1];
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int b = int.Parse(Console.ReadLine());
            int total = 0;
            for (int i = 0; i < n; i++) total += c[i];
            int overcharge = b - (total - c[k]) / 2;
            if (overcharge == 0)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(overcharge);
            }
        }
    }

    // https://www.hackerrank.com/challenges/divisible-sum-pairs
    class DivisibleSumPairs
    {
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int count = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (((a[i] + a[j]) % k) == 0) count++;
                }
            }

            Console.WriteLine(count);
        }
    }

    // https://www.hackerrank.com/challenges/between-two-sets
    class BetweenTwoSets
    {
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = Convert.ToInt32(tokens_n[0]);
            //int m = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse);
            int maxA = a.Max();
            int minB = b.Min();
            int count = 0;
            for (int i = maxA; i <= minB; i++)
            {
                if (a.All(ai => (i % ai) == 0) && b.All(bi => (bi % i) == 0)) count++;
            }

            Console.WriteLine(count);
        }
    }

    // https://www.hackerrank.com/challenges/kangaroo
    class Kangaroo
    {
        public static void Run()
        {
            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);
            if (v1 <= v2)
            {
                Console.WriteLine("NO");
            }
            else
            {
                int dv = v1 - v2;
                int dx = x2 - x1;
                Console.WriteLine((dx % dv) == 0 ? "YES" : "NO");
            }
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
