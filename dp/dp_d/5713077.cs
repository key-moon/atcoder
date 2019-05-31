// detail: https://atcoder.jp/contests/dp/submissions/5713077
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nw[0];
        var w = nw[1];
        long[] price = new long[w + 1];
        for (int i = 0; i < n; i++)
        {
            var wv = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = price.Length - wv[0] - 1; j >= 0; j--) price[j + wv[0]] = Max(price[j + wv[0]], price[j] + wv[1]);
        }
        Console.WriteLine(price.Max());
    }
}
