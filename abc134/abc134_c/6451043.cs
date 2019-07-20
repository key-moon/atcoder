// detail: https://atcoder.jp/contests/abc134/submissions/6451043
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        var accum = new int[1 + a.Length];
        var accumBack = new int[1 + a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            accum[i + 1] = Max(accum[i], a[i]);
        }
        for (int i = a.Length - 1; i >= 0; i--)
        {
            accumBack[i] = Max(accumBack[i + 1], a[i]);
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Max(accum[i], accumBack[i + 1]));
        }
    }
}
