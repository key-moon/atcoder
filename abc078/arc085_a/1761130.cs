// detail: https://atcoder.jp/contests/abc078/submissions/1761130
using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int N = Convert.ToInt32(input[0]);
            int M = Convert.ToInt32(input[1]);
            int result = (1900 * M + 100 * (N - M)) * Convert.ToInt32(Math.Pow(2, M));

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
