// detail: https://atcoder.jp/contests/abc116/submissions/5408116
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //k種類の寿司を各種類毎に
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var grouped = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).GroupBy(x => x[0]).Select(x => x.Select(y => y[1]).OrderByDescending(y => y).ToArray()).OrderByDescending(x => x[0]).ToArray();
        var candidate = grouped.SelectMany(x => x.Skip(1)).OrderByDescending(x => x).ToArray();
        int candidatePtr = 0;
        long score = grouped.Take(k).Sum(x => (long)x.First());
        long variousCount = Min(grouped.Length, k);
        int groupPtr = (int)variousCount - 1;
        for (long i = variousCount + 1; i <= k; i++) score += candidate[candidatePtr++];
        while (0 <= groupPtr && candidatePtr < candidate.Length && variousCount * variousCount - (variousCount - 1) * (variousCount - 1) <= candidate[candidatePtr] - grouped[groupPtr][0])
        {
            variousCount--;
            score += candidate[candidatePtr++];
            score -= grouped[groupPtr--][0];
        }
        Console.WriteLine(score + variousCount * variousCount);
    }
}
