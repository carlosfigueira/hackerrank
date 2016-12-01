using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode26
{
    class Twins
    {
        static int[] firstPrimes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317 };
        static List<int> primes;
        public static void Run()
        {
            primes = new List<int>(firstPrimes);
            int maxValue = (int)Math.Sqrt(1000000000) + 1;
            for (int i = firstPrimes[firstPrimes.Length - 1]; i <= maxValue; i += 2)
            {
                IsPrime(i, true);
            }

            int[] nm = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int n = nm[0];
            int m = nm[1];
            int count = 0;
            if (n <= 3 && m >= 5) count++; // handle case of (3, 5) first
            if ((n % 6) != 5) n = n + 5 - (n % 6); // all prime twins (other than 3,5 are of the form 6n-1,6n+1)
            for (int i = n; i <= m - 2; i += 6)
            {
                if (IsPrime(i) && IsPrime(i + 2))
                {
                    //Console.WriteLine("{0} and {1}", i, i + 2);
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static bool IsPrime(int n, bool addToList = false)
        {
            int max = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] > max) break;
                if ((n % primes[i]) == 0) return false;
            }

            primes.Add(n);
            return true;
        }
    }
}
