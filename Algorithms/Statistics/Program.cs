using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardDeviation.Run();
        }
    }

    // https://www.hackerrank.com/challenges/s10-standard-deviation
    class StandardDeviation
    {
        public static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            double mean = 0;
            for (int i = 0; i < N; i++) mean += X[i];
            mean /= N;

            double var = 0;
            for (int i = 0; i < N; i++)
            {
                var += (X[i] - mean) * (X[i] - mean);
            }
            var /= N;

            double sd = Math.Sqrt(var);
            Console.WriteLine("{0:.0}", sd);
        }
    }
    // https://www.hackerrank.com/challenges/s10-interquartile-range
    class InterquartileRange
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] F = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int N = 0;
            int i;
            for (i = 0; i < n; i++) N += F[i];
            int[] S = new int[N];
            i = 0;
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < F[j]; k++)
                {
                    S[i++] = X[j];
                }
            }
            Array.Sort(S);
            double q1, q3;
            if (N % 2 == 0)
            {
                q1 = Median(S, 0, N / 2);
                q3 = Median(S, N / 2, N);
            }
            else
            {
                q1 = Median(S, 0, N / 2);
                q3 = Median(S, N / 2 + 1, N);
            }
            Console.WriteLine("{0:.0}", q3 - q1);
        }
        static double Median(int[] arr, int start, int end)
        {
            int n = end - start;
            if (n % 2 == 1)
            {
                return arr[start + n / 2];
            }
            else
            {
                return (arr[start + n / 2] + arr[start + n / 2 - 1]) / 2.0;
            }
        }
    }

    // https://www.hackerrank.com/challenges/s10-quartiles
    class Quartiles
    {
        public static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(X);
            double q2 = Median(X, 0, N);
            double q1, q3;
            if (N % 2 == 0)
            {
                q1 = Median(X, 0, N / 2);
                q3 = Median(X, N / 2, N);
            }
            else
            {
                q1 = Median(X, 0, N / 2);
                q3 = Median(X, N / 2 + 1, N);
            }
            Console.WriteLine(q1);
            Console.WriteLine(q2);
            Console.WriteLine(q3);
        }
        static double Median(int[] arr, int start, int end)
        {
            int n = end - start;
            if (n % 2 == 1)
            {
                return arr[start + n / 2];
            }
            else
            {
                return (arr[start + n / 2] + arr[start + n / 2 - 1]) / 2.0;
            }
        }
    }
    // https://www.hackerrank.com/challenges/s10-weighted-mean
    class WeightedMean
    {
        public static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] W = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            double sum = 0, weightSum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += X[i] * W[i];
                weightSum += W[i];
            }
            Console.WriteLine("{0:.0}", sum / weightSum);
        }
    }
    // https://www.hackerrank.com/challenges/s10-basic-statistics
    class MedianMeanMode
    {
        public static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            int[] Numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(Numbers);
            double sum = 0;
            Dictionary<int, int> quantities = new Dictionary<int, int>();
            for (var i = 0; i < N; i++)
            {
                int n = Numbers[i];
                sum += n;
                if (!quantities.ContainsKey(n))
                {
                    quantities.Add(n, 1);
                }
                else
                {
                    quantities[n]++;
                }
            }
            double median;
            if ((N % 2) == 1)
            {
                median = Numbers[N / 2];
            }
            else
            {
                median = Numbers[N / 2] + Numbers[N / 2 - 1];
                median /= 2;
            }
            int mode = -1;
            int maxQuant = -1;
            foreach (var i in quantities.Keys)
            {
                var quant = quantities[i];
                if (quant > maxQuant || (quant == maxQuant && i < mode))
                {
                    mode = i;
                    maxQuant = quant;
                }
            }

            Console.WriteLine("{0:.0}", sum / N);
            Console.WriteLine("{0:.0}", median);
            Console.WriteLine(mode);
        }
    }
}
