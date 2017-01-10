#define LOCALTEST

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode28
{
    // https://www.hackerrank.com/contests/w28/challenges/the-great-xor
    class GreatXOR
    {
        public static void Run()
        {
#if LOCALTEST
            long[] numbers = new long[] { 1, 2, 10, 15, 16, 10000000000L };
            int q = numbers.Length;
#else
            int q = int.Parse(Console.ReadLine());
#endif
            for (int i = 0; i < q; i++)
            {
#if LOCALTEST
                long x = numbers[i];
#else
                long x = int.Parse(Console.ReadLine());
#endif
                int[] bits = ToBits(x);
                long count = 0;
                int maxBit = 1;
                for (int j = 0; j < bits.Length; j++)
                {
                    if (bits[j] == 1)
                    {
                        maxBit = j;
                    }
                }

                long temp = 1;
                for (int j = 0; j < maxBit; j++)
                {
                    if (bits[j] == 0)
                    {
                        count += temp;
                    }

                    temp *= 2;
                }

                Console.WriteLine(count);
            }
        }

        private static int[] ToBits(long l)
        {
            int[] result = new int[40];
            for (int i =0; i < result.Length; i++)
            {
                result[i] = (int)(l & 0x1);
                l /= 2;
            }

            return result;
        }
    }
}
