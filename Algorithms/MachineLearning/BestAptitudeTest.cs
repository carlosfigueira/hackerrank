using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning
{
    // https://www.hackerrank.com/challenges/the-best-aptitude-test
    class BestAptitudeTest
    {
        public static void Run()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0;i< T; i++)
            {
                RunTestCase();
            }
        }

        private static void RunTestCase()
        {
            Console.ReadLine(); // N not used - int N = int.Parse(Console.ReadLine());
            double[] gpas = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] t1 = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] t2 = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] t3 = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] t4 = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] t5 = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);

            double[][] tests = new[] { t1, t2, t3, t4, t5 };
            double maxCoef = -1;
            int bestTest = -1;
            for (int i = 0; i < tests.Length; i++)
            {
                double coef = SpearmansRankCorrelationCoefficient(gpas, tests[i]);
                if (coef > maxCoef)
                {
                    bestTest = i + 1;
                    maxCoef = coef;
                }
            }

            Console.WriteLine(bestTest);
        }

        private static double SpearmansRankCorrelationCoefficient(double[] X, double[] Y)
        {
            int n = X.Length;
            double[] ranksX = Array.ConvertAll(Ranks(X), x => (double)x);
            double[] ranksY = Array.ConvertAll(Ranks(Y), y => (double)y);

            double meanRanksX, sdRanksX, meanRanksY, sdRanksY;
            MeanAndSD(ranksX, out meanRanksX, out sdRanksX);
            MeanAndSD(ranksY, out meanRanksY, out sdRanksY);

            double cov = Covariance(ranksX, ranksY);
            double coef = cov / (sdRanksX * sdRanksY);
            return coef;
        }

        static double Covariance(double[] X, double[] Y)
        {
            double cov = 0;
            int n = X.Length;
            double meanX, meanY, sdX, sdY;
            MeanAndSD(X, out meanX, out sdX);
            MeanAndSD(Y, out meanY, out sdY);
            for (int i = 0; i < n; i++)
            {
                cov += (X[i] - meanX) * (Y[i] - meanY);
            }

            cov = cov / n;
            return cov;
        }
        static void MeanAndSD(double[] values, out double mean, out double sd)
        {
            mean = 0;
            int N = values.Length;
            for (int i = 0; i < N; i++) mean += values[i];
            mean /= N;

            double var = 0;
            for (int i = 0; i < N; i++)
            {
                var += (values[i] - mean) * (values[i] - mean);
            }
            var /= (N - 1);

            sd = Math.Sqrt(var);
        }

        private static int[] Ranks(double[] values)
        {
            int[] temp = Enumerable.Range(0, values.Length).ToArray();
            double[] newValues = values.ToArray();
            Array.Sort(newValues, temp);
            int[] ranks = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0 && newValues[i] == newValues[i - 1])
                {
                    ranks[temp[i]] = ranks[temp[i - 1]];
                }
                else
                {
                    ranks[temp[i]] = i + 1;
                }
            }

            return ranks;
        }

        internal static void TestRanks()
        {
            List<Tuple<double[], int[]>> tests = new List<Tuple<double[], int[]>>();
            tests.Add(Tuple.Create(new[] { 1.0, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }));
            tests.Add(Tuple.Create(new[] { 1.0, 3, 2, 4, 5 }, new[] { 1, 3, 2, 4, 5 }));
            tests.Add(Tuple.Create(new[] { 10.0, 2, 3, 4, 5 }, new[] { 5, 1, 2, 3, 4 }));
            tests.Add(Tuple.Create(new[] { 1.0, 3, 3, 4, 5 }, new[] { 1, 2, 2, 4, 5 }));
            tests.Add(Tuple.Create(new[] { 1.0, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1 }));
            foreach (var test in tests)
            {
                var expected = test.Item2;
                var actual = Ranks(test.Item1);
                bool equal = true;
                for (int i = 0; i < expected.Length; i++)
                {
                    if (actual[i] != expected[i])
                    {
                        equal = false;
                        break;
                    }
                }

                Console.WriteLine("Ranks for [{0}]: {1}", string.Join(", ", test.Item1), equal ? "CORRECT" : "INCORRECT");
            }
        }
    }
}
