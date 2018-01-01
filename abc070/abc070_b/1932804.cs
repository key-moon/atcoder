// detail: https://atcoder.jp/contests/abc070/submissions/1932804
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Max(Math.Min(N[3], N[1]) - Math.Max(N[2], N[0]),0));
    }
}
