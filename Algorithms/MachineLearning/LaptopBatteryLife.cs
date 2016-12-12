using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning
{
    // https://www.hackerrank.com/challenges/battery
    class LaptopBatteryLife
    {
        static double[] ChargingTimes;
        static double[] BatteryLastTime;
        public static void Run()
        {
            LoadTrainingData();
            double constant, slope;

            // Based on analysis of input, correlation is linear up to charge=4, constant afterwards
            // therefore only applying lm on charging times < 4
            List<double> linearChargingTimes = new List<double>();
            List<double> linearBatteryLife = new List<double>();
            for (int i =0; i < ChargingTimes.Length; i++)
            {
                if (ChargingTimes[i] <= 4)
                {
                    linearChargingTimes.Add(ChargingTimes[i]);
                    linearBatteryLife.Add(BatteryLastTime[i]);
                }
            }

            RunLinearModel(linearChargingTimes.ToArray(), linearBatteryLife.ToArray(), out slope, out constant);
            double chargingTime = Math.Min(4, double.Parse(Console.ReadLine()));
            double batteryTime = chargingTime * slope + constant;
            Console.WriteLine("{0:0.00}", batteryTime);
        }

        private static void RunLinearModel(double[] X, double[] Y, out double slope, out double constant)
        {
            double sumX = 0, sumY = 0, sumXY = 0, sumXSquare = 0;
            int N = X.Length;
            for (int i = 0; i < N; i++)
            {
                sumX += X[i];
                sumY += Y[i];
                sumXY += X[i] * Y[i];
                sumXSquare += X[i] * X[i];
            }

            double meanX = sumX / N;
            double meanY = sumY / N;
            slope = (N * sumXY - sumX * sumY) / (N * sumXSquare - (sumX * sumX));
            constant = meanY - slope * meanX;
        }

        private static void LoadTrainingData()
        {
            var lines = File.ReadAllLines("trainingdata.txt");
            ChargingTimes = new double[lines.Length];
            BatteryLastTime = new double[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                double[] values = Array.ConvertAll(lines[i].Split(','), double.Parse);
                ChargingTimes[i] = values[0];
                BatteryLastTime[i] = values[1];
            }
        }
    }
}
