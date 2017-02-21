using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOfCode29
{
    // https://www.hackerrank.com/contests/w29/challenges/day-of-the-programmer
    class DayOfTheProgrammer
    {
        public static void Run()
        {
            int year = int.Parse(Console.ReadLine());
            if (year == 1918)
            {
                Console.WriteLine("26.09.1918");
            }
            else
            {
                Console.WriteLine("{0}.09.{1}", IsLeap(year) ? "12" : "13", year);
            }
        }

        private static bool IsLeap(int year)
        {
            if (year < 1918)
            {
                return ((year % 4) == 0);
            }
            else
            {
                return ((year % 400) == 0) || (((year % 4) == 0) && ((year % 100) != 0));
            }
        }
    }
}
