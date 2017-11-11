// detail: https://atcoder.jp/contests/abc078/submissions/1760674
using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(input[0]);
            int y = Convert.ToInt32(input[1]);
            int z = Convert.ToInt32(input[2]);

            int result = (x - z) / (y + z);
            Console.WriteLine(result);
        }
    }
}
