// detail: https://atcoder.jp/contests/abc075/submissions/6424497
using System;
using System.IO;
using System.Linq;
using System.Numerics;
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var points = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        long res = long.MaxValue;
        for (int i = 0; i + k <= n; i++)
        {
            for (int j = i + k; j <= n; j++)
            {
                long height = points[j - 1][0] - points[i][0];
                var cands = points.Take(j).Skip(i).OrderBy(x => x[1]).ToArray();
                for (int l = 0; l + k <= cands.Length; l++)
                {
                    long width = cands[l + k - 1][1] - cands[l][1];
                    res = Min(res, height * width);
                }
            }
        }
        Console.WriteLine(res);
    }
}
