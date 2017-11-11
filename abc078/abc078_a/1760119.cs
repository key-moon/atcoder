// detail: https://atcoder.jp/contests/abc078/submissions/1760119
using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char a = input[0];
            char b = input[2];

            Console.WriteLine((a == b ? "=" : (a < b ? "<" : ">")));
        }
    }
}
