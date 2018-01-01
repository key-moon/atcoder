// detail: https://atcoder.jp/contests/abc074/submissions/1932782
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int k = int.Parse(Console.ReadLine());
        int[] x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        foreach (var boal in x)
        {
            res += Math.Min(boal, Math.Abs(k - boal)) * 2;
        }
        Console.WriteLine(res);
    }
}
