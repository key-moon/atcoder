// detail: https://atcoder.jp/contests/joi2020yo2/submissions/8922833
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
        int n = int.Parse(Console.ReadLine());
        var s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().ToArray()).ToArray();
        var t = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().ToArray()).ToArray();
        var s1 = Enumerable.Range(1, n).Select(x => s.Select(y => y[n - x]).ToArray()).ToArray();
        var s2 = Enumerable.Range(1, n).Select(x => s1.Select(y => y[n - x]).ToArray()).ToArray();
        var s3 = Enumerable.Range(1, n).Select(x => s2.Select(y => y[n - x]).ToArray()).ToArray();
        Console.WriteLine(new[] { t.GetDiff(s), t.GetDiff(s1) + 1, t.GetDiff(s2) + 2, t.GetDiff(s3) + 1 }.Min());
    }

    static int GetDiff(this char[][] t, char[][] x) => t.Zip(x, (a, b) => a.Zip(b, (c, d) => c == d ? 0 : 1).Sum()).Sum();
}
