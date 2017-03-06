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
            EigenValue3.Run();
        }
    }

    // https://www.hackerrank.com/challenges/eigenvalues-of-matrix-3
    class EigenValue3
    {
        public static void Run()
        {
            int[,] A = new int[2, 2] { { 2, -1 }, { -1, 2 } };
            int[,] Asquared = Square(A);

            Tuple<double, double> eigenA = EigenValue2.Eigenvalues(A);
            Tuple<double, double> eigenAsq = EigenValue2.Eigenvalues(Asquared);
            Console.WriteLine(eigenA.Item1);
            Console.WriteLine(eigenA.Item2);
            Console.WriteLine(eigenAsq.Item1);
            Console.WriteLine(eigenAsq.Item2);
        }

        internal static int[,] Square(int[,] matrix)
        {
            int len = matrix.GetLength(0);
            int[,] result = new int[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < len; k++)
                    {
                        sum += matrix[i, k] * matrix[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }
    }

    // https://www.hackerrank.com/challenges/eigenvalue-of-matrix-2
    class EigenValue2
    {
        public static void Run()
        {
            int[,] A = new int[2, 2]
            {
                { 1, 2 },
                { 2, 4 }
            };

            //     l^2 -5l = l(l - 5)
            // This quadratic equation has two roots, 0 and 5
            // So eigenvalues are 0 and 5

            Tuple<double, double> eigenvalues = Eigenvalues(A);
            Console.WriteLine("Eigenvalues for A: {0}, {1}", eigenvalues.Item1, eigenvalues.Item2);
        }

        internal static Tuple<double, double> Eigenvalues(int[,] A)
        {
            if (A.GetLength(0) != 2 || A.GetLength(1) != 2)
            {
                throw new ArgumentException("Function only works for 2x2 matrices");
            }

            // int[,] A = { { a, b }, { c, d } }
            // int[,] lI = { { l, 0 }, { 0, l } }
            // int[,] A - lI = { { a-l, b }, { c, d-l } }
            // determ(A - lI) = (a-l)(d-l) - bc =
            //     l^2 -(a+d)l + ad - bc = 0
            int a = 1;
            int b = -(A[0, 0] + A[1, 1]);
            int c = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            int delta = (b * b) - 4 * a * c;
            double sqrtDelta = Math.Sqrt(delta);
            double root1 = (-b - sqrtDelta) / (2 * a);
            double root2 = (-b + sqrtDelta) / (2 * a);
            return Tuple.Create(root1, root2);
        }
    }

    // https://www.hackerrank.com/challenges/eigenvalue-of-matrix-1
    class EigenValue1
    {
        public static void Run()
        {
            int[,] A = new int[3, 3]
            {
                { 1, -3, 3 },
                { 3, -5, 3 },
                { 6, -6, 4 }
            };

            // int[,] lI = { { l, 0, 0 }, { 0, l, 0 }, { 0, 0, l } }
            // int[,] A - lI = { { 1-l, -3, 3 }, { 3, -5-l, 3 }, { 6, -6, 4-l } }
            // determ(A - lI) = (1-l)(-5-l)(4-l) + (-3*3*6) + (3*3*-6) - (1-l)(3)(-6) - (-3)(3)(4-l) - (3)(-5-l)(6) =
            //     (-5-l)(4-5l+l^2) -54 -54 -(-18+18l) -(-36+9l) -(-90-18l) =
            //     (-20+25l-5l^2-4l+5l^2-l^3) -108 +18 -18l +36 -9l +90 +18l =
            //     -l^3 +21l -20 +36 -9l =
            //     -l^3 +12l + 16 = 0
            // By cubic factor, one of roots is l=4. Refactoring:
            //     -l^3 +12l +16 = (l - 4)(al^2 + bl + c) =     (a must be -1)
            //     -l^3 +12l +16 = (l - 4)(-l^2 + bl + c) =     (c must be -4)
            //     -l^3 +12l +16 = (l - 4)(-l^2 + bl -4) =     (b must be -4)
            //     -l^3 +12l +16 = (l - 4)(-l^2 -4l -4)
            // That quadratic equation has two (identical) roots, -2 and -2
            // So eigenvalues are -2, -2 and 4

            Console.WriteLine("Eigenvalues for A: -2, -2, 4");
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
