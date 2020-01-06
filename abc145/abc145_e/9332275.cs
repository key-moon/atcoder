// detail: https://atcoder.jp/contests/abc145/submissions/9332275
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nt[0];
        var t = nt[1];
        var orders = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        var res = 0;
        int[] maxHappiness = new int[t];
        foreach (var ab in orders)
        {
            var a = ab[0];
            var b = ab[1];
            res = Max(res, maxHappiness.Max() + b);
            for (int j = maxHappiness.Length - 1; j >= a; j--)
                maxHappiness[j] = Max(maxHappiness[j], maxHappiness[j - a] + b);
        }
        Console.WriteLine(res);
    }
}
