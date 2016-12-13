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
            int[] ranksX = Ranks(X);
            int[] ranksY = Ranks(Y);
            double coefInv = 0;
            for (var i = 0; i < n; i++)
            {
                coefInv += 6 * (ranksX[i] - ranksY[i]) * (ranksX[i] - ranksY[i]);
            }
            coefInv = coefInv / (n * (n * n - 1));
            double coef = 1 - coefInv;
            return coef;
        }

        private static int[] Ranks(double[] values)
        {
            int[] temp = Enumerable.Range(0, values.Length).ToArray();
            double[] newValues = values.ToArray();
            Array.Sort(newValues, temp);
            int[] ranks = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                ranks[temp[i]] = i + 1;
            }

            return ranks;
        }
    }
}
