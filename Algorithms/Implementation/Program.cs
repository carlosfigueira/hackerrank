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
                int count = 0;
                if (sra * sra == a)
                {
                    count++;
                    sra++;
                }

                if (a != b)
                {
                    int srb = (int)Math.Sqrt(b);
                    if (srb * srb == b)
                    {
                        count++;
                        srb--;
                    }

                    count += (srb - sra);
                }

                Console.WriteLine(count);
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
