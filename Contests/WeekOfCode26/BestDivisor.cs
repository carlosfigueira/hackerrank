using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode26
{
    // https://www.hackerrank.com/contests/w26/challenges/best-divisor
    class BestDivisor
    {
        static int[] primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317 };
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<Divisor> primeDivisors = GetPrimeDivisors(n);
            int bestSum = 1;
            int bestDivisor = 1;

            int[] divisors = new int[primeDivisors.Count];
            bool finished = n == 1;
            while (!finished)
            {
                int divisorCandidate = 1;
                for (int i = 0; i < divisors.Length; i++)
                {
                    for (int j = 0; j < divisors[i]; j++)
                    {
                        divisorCandidate *= primeDivisors[i].primeFactor;
                    }
                }
                int divisorScore = GetScore(divisorCandidate);

                if (divisorScore > bestSum || (divisorScore == bestSum && divisorCandidate < bestDivisor))
                {
                    bestDivisor = divisorCandidate;
                    bestSum = divisorScore;
                }

                // Move to next divisor
                for (int i = 0; i < divisors.Length; i++)
                {
                    divisors[i]++;
                    if (divisors[i] <= primeDivisors[i].exponent)
                    {
                        // Can still go
                        break;
                    }
                    else
                    {
                        divisors[i] = 0;
                        if (i == divisors.Length - 1)
                        {
                            finished = true;
                        }
                    }
                }
            }

            //Console.WriteLine("{0} ({1})", bestSum, bestDivisor);
            Console.WriteLine(bestDivisor);
        }
        static int GetScore(int n)
        {
            int divisorScore = 0;
            string divisorAsString = n.ToString();
            for (int i = 0; i < divisorAsString.Length; i++)
            {
                divisorScore += (int)(divisorAsString[i] - '0');
            }

            return divisorScore;
        }
        static List<Divisor> GetPrimeDivisors(int n)
        {
            int sqrtN = (int)(Math.Sqrt(n) + 0.1); // +.1 to account for rounding errors in sqrt
            List<Divisor> result = new List<Divisor>();
            int primeIndex = 0;
            int primeCandidate = primes[primeIndex];
            while (primeCandidate <= sqrtN)
            {
                int exponent = 0;
                while ((n % primeCandidate) == 0)
                {
                    n /= primeCandidate;
                    exponent++;
                }
                if (exponent > 0)
                {
                    result.Add(Divisor.Create(primeCandidate, exponent));
                }
                primeIndex++;
                primeCandidate = primes[primeIndex];
            }

            if (n > 1)
            {
                result.Add(Divisor.Create(n, 1)); // n is a prime
            }

            return result;
        }
        class Divisor
        {
            public int primeFactor { get; set; }
            public int exponent { get; set; }
            public static Divisor Create(int primeFactor, int exponent)
            {
                return new Divisor { primeFactor = primeFactor, exponent = exponent };
            }
        }
    }
}
