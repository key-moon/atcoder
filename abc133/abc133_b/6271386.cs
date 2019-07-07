// detail: https://atcoder.jp/contests/abc133/submissions/6271386
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var points = Enumerable.Repeat(0, nd[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var res = 0;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                var len = points[i].Zip(points[j], (x, y) => Abs(x - y) * Abs(x - y)).Sum();
                var sqrtLen = (long)Sqrt(len);
                if (sqrtLen * sqrtLen == len) res++;
            }
        }
        Console.WriteLine(res);
    }
}
