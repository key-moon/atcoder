// detail: https://atcoder.jp/contests/abc034/submissions/5713183
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var vessels = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new { SaltWeight = x[1] / 100.0 * x[0] , TotalWeight = x[0] }).ToArray();
        double valid = 0;
        double invalid = 1;
        for (int iter = 0; iter < 1000; iter++)
        {
            var mid = (valid + invalid) / 2;
            if (vessels.Select(x => x.SaltWeight - mid * x.TotalWeight).OrderByDescending(x => x).Take(k).Sum() >= 0) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid * 100);
    }
}
