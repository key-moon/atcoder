// detail: https://atcoder.jp/contests/abc023/submissions/6214557
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var rck = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rck[0];
        var c = rck[1];
        var k = rck[2];
        int[] rSum = new int[c];
        int[] cSum = new int[r];
        int n = int.Parse(Console.ReadLine());
        var rcs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        foreach (var rc in rcs)
        {
            cSum[rc[0]]++;
            rSum[rc[1]]++;
        }
        long res = 0;
        var rCounts = rSum.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        for (int i = 0; i < cSum.Length; i++)
        {
            if (rCounts.ContainsKey(k - cSum[i])) res += rCounts[k - cSum[i]];
        }
        foreach (var rc in rcs)
        {
            if (cSum[rc[0]] + rSum[rc[1]] == k) res--;
            if (cSum[rc[0]] + rSum[rc[1]] == k + 1) res++;
        }
        Console.WriteLine(res);
    }
}
