// detail: https://atcoder.jp/contests/abc133/submissions/6278709
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var res = new long[n];
        for (int i = 1; i < n; i++)
        {
            res[i] = a[i - 1] - res[i - 1];
        }
        res[0] = (a.Last() - res.Last()) / 2;
        for (int i = 1; i < n; i++)
        {
            res[i] = a[i - 1] - res[i - 1];
        }
        Console.WriteLine(string.Join(" ", res.Select(x => x * 2)));
    }
}
