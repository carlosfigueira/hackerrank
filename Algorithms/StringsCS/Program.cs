using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Pangram.Run();
            //TwoCharacters.Run();
        }
    }

    // https://www.hackerrank.com/challenges/pangrams
    class Pangram
    {
        public static void Run()
        {
            var str = Console.ReadLine();
            bool[] present = new bool[26];
            for (var i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ('A' <= c && c <= 'Z') c = (char)(c + 'a' - 'A');
                if ('a' <= c && c <= 'z')
                {
                    present[c - 'a'] = true;
                }
            }

            bool isPangram = true;
            for (var i = 0; i < present.Length; i++)
            {
                if (!present[i])
                {
                    isPangram = false;
                    break;
                }
            }

            Console.WriteLine(isPangram ? "pangram" : "not pangram");
        }
    }
    // https://www.hackerrank.com/challenges/two-characters
    class TwoCharacters
    {
        public static void Run()
        {
            int len = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            char[] chars = s.Distinct().ToArray();
            int result = 0;
            if (chars.Length > 1)
            {
                for (var ic1 = 0; ic1 < chars.Length - 1; ic1++)
                {
                    for (var ic2 = ic1 + 1; ic2 < chars.Length; ic2++)
                    {
                        char c1 = chars[ic1];
                        char c2 = chars[ic2];

                        var twoCharLen = 0;
                        char current = '\0';
                        for (var i = 0; i < len; i++)
                        {
                            if (s[i] == c1)
                            {
                                if (current == c1)
                                {
                                    // Not a candidate
                                    twoCharLen = 0;
                                    break;
                                }

                                twoCharLen++;
                                current = c1;
                            }
                            else if (s[i] == c2)
                            {
                                if (current == c2)
                                {
                                    // Not a candidate
                                    twoCharLen = 0;
                                    break;
                                }

                                twoCharLen++;
                                current = c2;
                            }
                        }

                        if (twoCharLen > result)
                        {
                            result = twoCharLen;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
