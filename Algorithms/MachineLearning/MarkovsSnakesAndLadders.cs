using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MachineLearning
{
    class MarkovsSnakesAndLadders
    {
        const int NumGames = 5000;
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            Random rndGen = new Random(1);
            for (int i = 0; i < n; i++)
            {
                SnakesLaddersSimulation sim = SnakesLaddersSimulation.ReadInput();
                int sum = 0;
                int cGames = 0;
                for (int s = 0; s < NumGames; s++)
                {
                    int thisGame = sim.SimulateGame(rndGen);
                    if (thisGame > 0)
                    {
                        cGames++;
                        sum += thisGame;
                    }
                }

                Console.WriteLine(sum / cGames);
            }
        }

        class SnakesLaddersSimulation
        {
            static readonly Regex regex = new Regex(@"(\d+)\,(\d+)");

            private double[] DieNumberProbabilities;
            private double[] DieNumberAccumProbabilities;

            private Dictionary<int, int> Snakes = new Dictionary<int, int>();
            private Dictionary<int, int> Ladders = new Dictionary<int, int>();

            public int SimulateGame(Random rndGen)
            {
                int position = 1;
                int count = 0;

                while (count < 1000 && position != 100)
                {
                    int die = this.RollDie(rndGen);
                    count++;
                    if (position + die <= 100)
                    {
                        position += die;
                        if (this.Snakes.ContainsKey(position))
                        {
                            position = this.Snakes[position];
                        }
                        else if (this.Ladders.ContainsKey(position))
                        {
                            position = this.Ladders[position];
                        }
                    }
                }

                return position == 100 ? count : -1;
            }

            private int RollDie(Random rndGen)
            {
                double val = rndGen.NextDouble();
                for (int i = 0; i < this.DieNumberAccumProbabilities.Length; i++)
                {
                    if (val < this.DieNumberAccumProbabilities[i])
                    {
                        return i + 1;
                    }
                }

                return 6;
            }

            public static SnakesLaddersSimulation ReadInput()
            {
                SnakesLaddersSimulation result = new SnakesLaddersSimulation();
                result.DieNumberProbabilities = Array.ConvertAll(
                    Console.ReadLine().Trim().Split(','), double.Parse);
                result.DieNumberAccumProbabilities = new double[6];
                for (int i = 0; i < 6; i++)
                {
                    result.DieNumberAccumProbabilities[i] = (i == 0) ?
                        result.DieNumberProbabilities[i] :
                        result.DieNumberProbabilities[i] + result.DieNumberAccumProbabilities[i - 1];
                }

                Console.ReadLine(); // cLadders, cSnakes, will take from next lines
                // ladders
                foreach (Match match in regex.Matches(Console.ReadLine()))
                {
                    int start = int.Parse(match.Groups[1].Value);
                    int end = int.Parse(match.Groups[2].Value);
                    result.Ladders.Add(start, end);
                }

                // snakes
                foreach (Match match in regex.Matches(Console.ReadLine()))
                {
                    int start = int.Parse(match.Groups[1].Value);
                    int end = int.Parse(match.Groups[2].Value);
                    result.Snakes.Add(start, end);
                }

                return result;
            }
        }
    }
}
