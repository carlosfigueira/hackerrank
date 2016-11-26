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
            SpearmansRankCorrelationCoefficient.Run();
        }
    }

    // https://www.hackerrank.com/challenges/s10-least-square-regression-line
    class LeastSquareRegressionLine
    {
        public static void Run()
        {
            int N = 5;
            double sumX = 0, sumY = 0, sumXY = 0, sumXSquare = 0;
            for (int i = 0; i < N; i++)
            {
                double[] values = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
                double x = values[0];
                double y = values[1];
                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumXSquare += x * x;
            }

            double meanX = sumX / N;
            double meanY = sumY / N;
            double b = (N * sumXY - sumX * sumY) / (N * sumXSquare - (sumX * sumX));
            double a = meanY - b * meanX;

            double mathGrade = 80;
            double statGrade = a + b * mathGrade;
            Console.WriteLine("{0:0.000}", statGrade);
        }
    }

    // https://www.hackerrank.com/challenges/s10-pearson-correlation-coefficient
    class SpearmansRankCorrelationCoefficient
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            double[] X = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            int[] ranksX = Ranks(X);
            double[] Y = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            int[] ranksY = Ranks(Y);
            double coefInv = 0;
            for (var i = 0; i < n; i++)
            {
                coefInv += 6 * (ranksX[i] - ranksY[i]) * (ranksX[i] - ranksY[i]);
            }
            coefInv = coefInv / (n * (n * n - 1));
            double coef = 1 - coefInv;
            Console.WriteLine("{0:0.000}", coef);
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

    // https://www.hackerrank.com/challenges/s10-pearson-correlation-coefficient
    class PearsonCorrelationCoefficient1
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            double[] X = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double[] Y = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), double.Parse);
            double meanX, sdX, meanY, sdY;
            MeanAndSD(X, out meanX, out sdX);
            MeanAndSD(Y, out meanY, out sdY);

            double rho = 0;
            for (int i = 0; i < n; i++)
            {
                rho += (X[i] - meanX) * (Y[i] - meanY);
            }
            rho = rho / (n * sdX * sdY);
            Console.WriteLine("{0:0.000}", rho);
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
            var /= N;

            sd = Math.Sqrt(var);
        }
    }

    // https://www.hackerrank.com/challenges/s10-the-central-limit-theorem-3
    class CentralLimitTheorem3
    {
        static void Run()
        {
            int sampleSize = int.Parse(Console.ReadLine());
            double populationMean = double.Parse(Console.ReadLine());
            double populationSD = double.Parse(Console.ReadLine());
            double percentageToCover = double.Parse(Console.ReadLine());
            double zValue = double.Parse(Console.ReadLine());

            double sampleSD = populationSD / Math.Sqrt(sampleSize);
            double sampleMean = populationMean;

            double lowBound = sampleMean - zValue * sampleSD;
            double highBound = sampleMean + zValue * sampleSD;
            Console.WriteLine("{0:0.00}", lowBound);
            Console.WriteLine("{0:0.00}", highBound);
        }
    }

    // https://www.hackerrank.com/challenges/s10-the-central-limit-theorem-2
    class CentralLimitTheorem2
    {
        static void Run()
        {
            int ticketsLeft = int.Parse(Console.ReadLine());
            int numStudents = int.Parse(Console.ReadLine());
            double meanTicketsPerStudent = double.Parse(Console.ReadLine());
            double sdTicketsPerStudent = double.Parse(Console.ReadLine());

            double meanRequiredTickets = numStudents * meanTicketsPerStudent;
            double sdRequiredTickets = sdTicketsPerStudent * Math.Sqrt(numStudents);

            double prob = Phi((ticketsLeft - meanRequiredTickets) / sdRequiredTickets);
            Console.WriteLine("{0:0.0000}", prob);
        }
        static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }

    // https://www.hackerrank.com/challenges/s10-the-central-limit-theorem-1
    class CentralLimitTheorem1
    {
        static void Run()
        {
            double maxWeight = double.Parse(Console.ReadLine());
            int numBoxes = int.Parse(Console.ReadLine());
            double meanBoxWeight = double.Parse(Console.ReadLine());
            double sdBoxWeight = double.Parse(Console.ReadLine());

            double meanAllBoxes = meanBoxWeight * numBoxes;
            double sdAllBoxes = sdBoxWeight * Math.Sqrt(numBoxes);

            double prob = Phi((maxWeight - meanAllBoxes) / sdAllBoxes);
            Console.WriteLine("{0:0.0000}", prob);
        }
        static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }

    // https://www.hackerrank.com/challenges/s10-normal-distribution-2
    class NormalDistribution2
    {
        static void Run()
        {
            double[] values = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double mean = values[0];
            double sd = values[1];
            double value1 = double.Parse(Console.ReadLine());
            double overValue1 = 1 - Phi((value1 - mean) / sd);
            Console.WriteLine("{0:0.00}", 100 * overValue1);
            double value2 = double.Parse(Console.ReadLine());
            double underValue2 = Phi((value2 - mean) / sd);
            double overValue2 = 1 - underValue2;
            Console.WriteLine("{0:0.00}", 100 * overValue2);
            Console.WriteLine("{0:0.00}", 100 * underValue2);
        }
        static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }

    // https://www.hackerrank.com/challenges/s10-normal-distribution-1
    class NormalDistribution1
    {
        static void Run()
        {
            double[] values = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double mean = values[0];
            double sd = values[1];
            double value1 = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:0.000}", Phi((value1 - mean) / sd));
            values = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double cum1 = Phi((values[0] - mean) / sd);
            double cum2 = Phi((values[1] - mean) / sd);
            Console.WriteLine("{0:0.000}", cum2 - cum1);
        }
        static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }

    // https://www.hackerrank.com/challenges/s10-poisson-distribution-2
    class PoissonDistribution2
    {
        static void Run()
        {
            double[] values = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double meanX = values[0];
            double meanY = values[1];

            double expectedXSquare = meanX + meanX * meanX;
            double expectedYSquare = meanY + meanY * meanY;
            double costA = 160 + 40 * expectedXSquare;
            double costB = 128 + 40 * expectedYSquare;
            Console.WriteLine("{0:0.000}", costA);
            Console.WriteLine("{0:0.000}", costB);
        }
    }

    // https://www.hackerrank.com/challenges/s10-poisson-distribution-1
    class PoissonDistribution1
    {
        static void Run()
        {
            double lambda = double.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            double P_K_lambda = Math.Pow(lambda, K) * Math.Pow(Math.E, -lambda) / Factorial(K);
            Console.WriteLine("{0:0.000}", P_K_lambda);
        }

        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }
    }

    // https://www.hackerrank.com/challenges/s10-geometric-distribution-2
    class GeometricDistribution2
    {
        static void Run()
        {
            double[] ratioValues = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double pDefective = ratioValues[0] / ratioValues[1];
            int defectiveBeforeOrAtInspection = int.Parse(Console.ReadLine());
            double result = 0;
            for (int i = 1; i <= defectiveBeforeOrAtInspection; i++)
            {
                double pDefectiveAtIthInspection = Math.Pow(1 - pDefective, i - 1) * pDefective;
                result += pDefectiveAtIthInspection;
            }
            Console.WriteLine("{0:0.000}", result);
        }
    }

    // https://www.hackerrank.com/challenges/s10-geometric-distribution-1
    class GeometricDistribution1
    {
        static void Run()
        {
            double[] ratioValues = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double pDefective = ratioValues[0] / ratioValues[1];
            int defectiveAtInspection = int.Parse(Console.ReadLine());
            double result = Math.Pow(1 - pDefective, defectiveAtInspection - 1) * pDefective;
            Console.WriteLine("{0:0.000}", result);
        }
    }

    // https://www.hackerrank.com/challenges/s10-binomial-distribution-2
    class BinomialDistribution2
    {
        static void Run()
        {
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            double pDefective = values[0] / 100.0;
            int trials = values[1];

            double p0Rejects = pBinom(0, trials, pDefective);
            double p1Rejects = pBinom(1, trials, pDefective);
            double p2Rejects = pBinom(2, trials, pDefective);

            double pAtLeast2Rejects = 1 - p0Rejects - p1Rejects;
            double pNoMoreThan2Rejects = p0Rejects + p1Rejects + p2Rejects;

            Console.WriteLine("{0:0.000}", pNoMoreThan2Rejects);
            Console.WriteLine("{0:0.000}", pAtLeast2Rejects);
        }
        static double pBinom(int successCount, int trialCount, double pSuccess)
        {
            int nChooseX = 1;
            for (int i = 0; i < successCount; i++)
            {
                nChooseX *= (trialCount - i);
            }
            for (int i = 0; i < successCount; i++)
            {
                nChooseX /= i + 1;
            }
            return nChooseX * Math.Pow(pSuccess, successCount) * Math.Pow(1 - pSuccess, trialCount - successCount);
        }
    }

    // https://www.hackerrank.com/challenges/s10-binomial-distribution-1
    class BinomialDistribution1
    {
        static void Run()
        {
            double[] ratioValues = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double pBoy = ratioValues[0] / (ratioValues[0] + ratioValues[1]);

            double p3Boys = pBinom(3, 6, pBoy);
            double p4Boys = pBinom(4, 6, pBoy);
            double p5Boys = pBinom(5, 6, pBoy);
            double p6Boys = pBinom(6, 6, pBoy);
            Console.WriteLine("{0:0.000}", p3Boys + p4Boys + p5Boys + p6Boys);

            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        }
        static double pBinom(int successCount, int trialCount, double pSuccess)
        {
            int nChooseX = 1;
            for (int i = 0; i < successCount; i++)
            {
                nChooseX *= (trialCount - i);
            }
            for (int i = 0; i < successCount; i++)
            {
                nChooseX /= i + 1;
            }
            return nChooseX * Math.Pow(pSuccess, successCount) * Math.Pow(1 - pSuccess, trialCount - successCount);
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
