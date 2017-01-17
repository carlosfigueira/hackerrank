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
            SherlockAndMinMax.Run();
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-minimax
    // Hard, 70
    class SherlockAndMinMax
    {
        public static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int[] PQ = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int P = PQ[0];
            int Q = PQ[1];

            Array.Sort(A);
            int max = 0;
            int number = P;

            if (P <= A[0])
            {
                max = A[0] - P;
                number = P;
            }

            int i = 0;
            while (i < N - 1 && P > A[i + 1]) i++;

            while (i < N - 1 && Q >= A[i])
            {
                int mid = (A[i] + A[i + 1]) / 2;
                int maxForSection = (A[i + 1] - A[i]) / 2;

                if (P <= mid && mid <= Q)
                {
                    if (maxForSection > max)
                    {
                        max = maxForSection;
                        number = mid;
                    }
                }
                else if (P > mid)
                {
                    int maxForP = A[i + 1] - P;
                    if (maxForP > max)
                    {
                        max = maxForP;
                        number = P;
                    }
                }
                else if (Q < mid)
                {
                    int maxForQ = Q - A[i];
                    if (maxForQ > max)
                    {
                        max = maxForQ;
                        number = Q;
                    }
                }

                i++;
            }

            if (Q >= A[N - 1])
            {
                if (Q - A[N - 1] > max)
                {
                    max = Q - A[N - 1];
                    number = Q;
                }
            }

            Console.WriteLine(number);
        }
    }

    // https://www.hackerrank.com/challenges/greedy-florist
    class GreedyFlorist
    {
        public static void Run()
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int N = nk[0];
            int K = nk[1];

            Array.Sort(C);

            int totalCost = 0;
            int multiplier = 1;
            while (N > 0)
            {
                int flowersThisRound = Math.Min(K, N);
                for (int i = 0; i < flowersThisRound; i++)
                {
                    totalCost += C[N - i - 1] * multiplier;
                }

                N -= flowersThisRound;
                multiplier++;
            }

            Console.WriteLine(totalCost);
        }
    }

    // https://www.hackerrank.com/challenges/mark-and-toys
    class MarkAndToys
    {
        public static void Run()
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = nk[0];
            int k = nk[1];
            Array.Sort(P);
            int count = 0;
            while (count < n && k > 0)
            {
                k -= P[count];
                count++;
            }

            if (k < 0) count--;
            Console.WriteLine(count);
        }
    }

    // https://www.hackerrank.com/challenges/largest-permutation
    class LargestPermutation
    {
        public static void Run()
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] N = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = nk[0];
            int k = nk[1];

            int[] indices = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                indices[N[i]] = i;
            }

            for (int i = 0; i < n && k > 0; i++)
            {
                int nextHighest = n - i;
                if (N[i] == nextHighest)
                {
                    // Already maximum
                    continue;
                }

                int nextHighestIndex = indices[nextHighest];
                int temp = N[i];
                N[i] = nextHighest;
                N[nextHighestIndex] = temp;
                indices[temp] = nextHighestIndex;
                indices[nextHighest] = i;
                k--;
            }

            Console.WriteLine(string.Join(" ", N));
        }
    }

    // https://www.hackerrank.com/challenges/priyanka-and-toys
    class PriyankaAndToys
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] w = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(w);
            int current = -1000;
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                if (w[i] - current > 4)
                {
                    result++;
                    current = w[i];
                }
            }

            Console.WriteLine(result);
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-the-beast
    class SherlockAndTheBeast
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == 1 || n == 2 || n == 4 || n == 7)
                {
                    Console.WriteLine(-1);
                }
                else if ((n % 3) == 0)
                {
                    Console.WriteLine(new string('5', n));
                    //Console.WriteLine("5*{0}", n);
                }
                else
                {
                    int fives = n - n % 15;
                    int threes = 0;
                    switch (n % 15)
                    {
                        case 5:
                        case 10:
                            threes = n - fives;
                            break;
                        case 1:
                            fives -= 9;
                            threes += 10;
                            break;
                        case 2:
                            fives -= 3;
                            threes += 5;
                            break;
                        case 4:
                            fives -= 6;
                            threes += 10;
                            break;
                        case 7:
                            fives -= 3;
                            threes += 10;
                            break;
                        case 8:
                            fives += 3;
                            threes += 5;
                            break;
                        case 11:
                            fives += 6;
                            threes += 5;
                            break;
                        case 13:
                            fives += 3;
                            threes += 10;
                            break;
                        case 14:
                            fives += 9;
                            threes += 5;
                            break;
                    }

                    //Console.WriteLine("5*{0}, 3*{1}", fives, threes);
                    Console.Write(new string('5', fives));
                    Console.WriteLine(new string('3', threes));
                }
            }
        }
    }

    // https://www.hackerrank.com/challenges/strange-advertising
    class StrangeAdvertising {
        public static void Run() {
            int d = 5;
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++) {
                int liked = d / 2;
                sum += liked;
                d = liked * 3;
                // Console.WriteLine("day {0}: sum = {1}, d = {2}", i + 1, sum, d);
            }
            Console.WriteLine(sum);
        }
    }
    
    // https://www.hackerrank.com/challenges/angry-professor
    class AngryProfessor {
        public static void Run() {
            int t = Convert.ToInt32(Console.ReadLine());
            for(int a0 = 0; a0 < t; a0++){
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                string[] a_temp = Console.ReadLine().Split(' ');
                int[] a = Array.ConvertAll(a_temp,Int32.Parse);
                int onTime = 0;
                for (int i = 0; i < n; i++) {
                    if (a[i] <= 0) onTime++;
                }
                Console.WriteLine(onTime < k ? "YES" : "NO");
            }
        }
    }

    // https://www.hackerrank.com/challenges/sock-merchant
    class SockMerchant {
        public static void Run() {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp,Int32.Parse);
            int[] counts = new int[100];
            for (int i = 0; i < n; i++) {
                counts[c[i] - 1]++;
            }
            int result = 0;
            for (int i = 0; i < counts.Length; i++) {
                result += counts[i] / 2;
            }
            Console.WriteLine(result);
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
