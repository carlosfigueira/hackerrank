using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            DeterminantOfMatrix1.Run();
        }
    }

    class DeterminantOfMatrix3
    {
        public static void Run()
        {
            // |a b c|
            // |d e f| = -6
            // |g h i|
            //
            // aei + bfg + cdh - ceg - bdi - afh = -6
            //
            // |d e f|
            // |g h i| = ?
            // |a b c|
            //
            // cdh + aei + bfg - bdi - ceg - afh = ? = -6
            Console.WriteLine("Det = -6");
        }
    }

    // https://www.hackerrank.com/challenges/determinant-of-the-matrix-1
    class DeterminantOfMatrix1
    {
        public static void Run()
        {
            int[,] mat = StringToMatrix(@"3  0  0 -2  4
                                          0  2  0  0  0
                                          0 -1  0  5 -3
                                         -4  0  1  0  6
                                          0 -1  0  3  2");
            Console.WriteLine(Determinant(mat));
        }

        static int[,] StringToMatrix(string str)
        {
            string[] lines = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int n = lines.Length;
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] parts = lines[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] values = Array.ConvertAll(parts, int.Parse);
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = values[j];
                }
            }

            return result;
        }

        public static int Determinant(int[,] matrix)
        {
            int len = matrix.GetLength(0);
            if (len != matrix.GetLength(1))
            {
                throw new ArgumentException("Matrix dimensions must be the same");
            }

            if (len == 1)
            {
                return matrix[0, 0];
            }

            int result = 0;
            for (int i = 0; i < len; i++)
            {
                if (matrix[0, i] != 0)
                {
                    int[,] aux = new int[len - 1, len - 1];
                    for (int j1 = 0; j1 < len - 1; j1++)
                    {
                        for (int j2 = 0; j2 < len - 1; j2++)
                        {
                            aux[j1, j2] = matrix[j1 + 1, j2 < i ? j2 : j2 + 1];
                        }
                    }

                    result += ((i % 2 == 0) ? 1 : -1) * matrix[0, i] * Determinant(aux);
                }
            }

            return result;
        }
    }
}
