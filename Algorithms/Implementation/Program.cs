using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            MaximumSubarraySum.Run();
        }
    }

    // https://www.hackerrank.com/challenges/connected-cell-in-a-grid
    // Medium, 50
    class ConnectedCellsInAGrid
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[][] grid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }

            int maxRegion = 0;
            //PrintGrid(grid);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int regionSize = CalculateRegion(grid, i, j, n, m);
                        //PrintGrid(grid);
                        if (regionSize > maxRegion)
                        {
                            maxRegion = regionSize;
                        }
                    }
                }
            }

            Console.WriteLine(maxRegion);
        }

        static void PrintGrid(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine(string.Join(" ", grid[i]));
            }
            Console.WriteLine();
        }

        static int CalculateRegion(int[][] grid, int i, int j, int n, int m)
        {
            Queue<Tuple<int, int>> toExplore = new Queue<Tuple<int, int>>();
            toExplore.Enqueue(Tuple.Create(i, j));
            int size = 0;
            while (toExplore.Count > 0)
            {
                Tuple<int, int> next = toExplore.Dequeue();
                i = next.Item1;
                j = next.Item2;
                if (grid[i][j] == 1)
                {
                    size++;
                    grid[i][j] = 8;
                    if (i > 0 && grid[i - 1][j] == 1) toExplore.Enqueue(Tuple.Create(i - 1, j)); // S
                    if (i < n - 1 && grid[i + 1][j] == 1) toExplore.Enqueue(Tuple.Create(i + 1, j)); // N
                    if (j > 0 && grid[i][j - 1] == 1) toExplore.Enqueue(Tuple.Create(i, j - 1)); // W
                    if (j < m - 1 && grid[i][j + 1] == 1) toExplore.Enqueue(Tuple.Create(i, j + 1)); // E
                    if (i > 0 && j > 0 && grid[i - 1][j - 1] == 1) toExplore.Enqueue(Tuple.Create(i - 1, j - 1)); // SE
                    if (i < n - 1 && j < m - 1 && grid[i + 1][j + 1] == 1) toExplore.Enqueue(Tuple.Create(i + 1, j + 1)); // NW
                    if (i < n - 1 && j > 0 && grid[i + 1][j - 1] == 1) toExplore.Enqueue(Tuple.Create(i + 1, j - 1)); // SW
                    if (i > 0 && j < m - 1 && grid[i - 1][j + 1] == 1) toExplore.Enqueue(Tuple.Create(i - 1, j + 1)); // NE
                }
            }

            return size;
        }
    }

    // https://www.hackerrank.com/challenges/maximum-subarray-sum
    // Hard, 65
    // INCORRECT
    class MaximumSubarraySum
    {
        static class Console
        {
            static bool useConsole = false;
            static bool initialized = false;
            static string fileName = @"D:\temp\deleteme\input.txt";
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
                long[] nm = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                int n = (int)nm[0];
                long m = nm[1];
                long[] A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                for (int i = 0; i < n; i++)
                {
                    A[i] = A[i] % m;
                }

                long max = -1;
                long[] upToNPrev = new long[n];
                max = upToNPrev[0] = A[0];
                for (int i = 1; i < n; i++)
                {
                    for (int j = i; j >= 1; j--)
                    {
                        long cell = (upToNPrev[j - 1] + A[j]) % m;
                        upToNPrev[j] = cell;
                        if (cell > max) max = cell;
                    }

                    upToNPrev[0] = A[i];
                    if (A[i] > max) max = A[i];
                }

                //long[] partialSums = new long[n];
                //partialSums[0] = A[0];
                //for (int i = 1; i < n; i++)
                //{
                //    partialSums[i] = (partialSums[i - 1] + A[i]) % m;
                //}

                //List<long> found = new List<long>();
                //long max = 0;

                //for (int i = 0; i < n; i++)
                //{
                //    long x = partialSums[i];
                //    int j = BisectRight(found, x);
                //    max = Math.Max(max, x);
                //    if (j < i)
                //    {
                //        // sub array from j+1, i may be a solution
                //        max = Math.Max(max, (partialSums[i] - found[j]) % m);
                //    }

                //    found.Insert(j, x);
                //}

                System.Console.WriteLine(max);
            }
        }

        static int BisectRight(List<long> arr, long x, int index = 0, int count = -1)
        {
            if (count == -1) count = arr.Count;

            if (count == 0) return 0;
            if (x < arr[index]) return 0;
            if (x >= arr[index + count - 1]) return index + count;
            int mid = index + count / 2;
            if (x == arr[mid]) return mid + 1;
            if (x < arr[mid]) return BisectRight(arr, x, index, count / 2);
            return BisectRight(arr, x, mid, count - count / 2);
        }
    }

    // https://www.hackerrank.com/challenges/pairs
    // Medium, 50
    class Pairs
    {
        static int pairs(int[] a, int k)
        {
            Array.Sort(a);
            int n = a.Length;
            int p1 = 0, p2 = 1;
            int count = 0;
            while (p2 < n)
            {
                int diff = a[p2] - a[p1];
                if (diff == k)
                {
                    count++;
                    p1++;
                    p2++;
                }
                else if (diff < k)
                {
                    // less than k, need to advance higher pointer
                    p2++;
                }
                else
                {
                    // more than k, need to advance lower pointer
                    p1++;
                    if (p1 == p2)
                    {
                        p2++;
                    }
                }
            }

            return count;
        }
        public static void Run()
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //int n = nk[0];
            int k = nk[1];
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(pairs(A, k));
        }
    }

    // https://www.hackerrank.com/challenges/missing-numbers
    // Easy, 45
    class MissingNumbers
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int m = int.Parse(Console.ReadLine());
            int[] B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] freq = new int[10001];
            for (int i = 0; i < n; i++)
            {
                freq[A[i]]--;
            }

            for (int i = 0; i < m; i++)
            {
                freq[B[i]]++;
            }

            bool first = true;
            for (int i = 1; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                    Console.Write(i);
                }
            }

            Console.WriteLine();
        }
    }

    // https://www.hackerrank.com/challenges/sherlock-and-array
    // Easy, 40
    class SherlockAndArray
    {
        public static void Run()
        {
            int T = int.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int N = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (N == 1)
                {
                    Console.WriteLine("YES");
                }
                else if (N == 2)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    int totalLeft = 0, totalRight = 0, iLeft = 0, iRight = N - 1;
                    while (iRight - iLeft >= 1)
                    {
                        if (totalLeft < totalRight)
                        {
                            totalLeft += A[iLeft++];
                        }
                        else
                        {
                            totalRight += A[iRight--];
                        }
                    }

                    if (totalLeft == totalRight)
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
            }
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
