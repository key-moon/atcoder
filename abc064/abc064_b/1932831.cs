// detail: https://atcoder.jp/contests/abc064/submissions/1932831
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(N.Max() - N.Min());
    }
}
