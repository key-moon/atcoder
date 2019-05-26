// detail: https://atcoder.jp/contests/abc128/submissions/5641873
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
        var k = nk[1];
        var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long max = 0;
        for (int i = 0; i <= v.Length; i++)
        {
            for (int j = 0; j <= v.Length; j++)
            {
                var remainOps = k - (i + j);
                if (remainOps < 0 || v.Length < i + j) continue;

                List<long> gems = new List<long>();
                for (int front = 0, count = 0; count < i; front++, count++) gems.Add(v[front]);
                for (int back = v.Length - 1, count = 0; count < j; back--, count++) gems.Add(v[back]);
                var taked = gems.OrderBy(x => x).TakeWhile(x => x < 0).Take(remainOps).Sum();
                max = Max(max, gems.Sum() - taked);
            }
        }
        Console.WriteLine(max);
    }
}
