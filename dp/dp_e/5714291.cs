// detail: https://atcoder.jp/contests/dp/submissions/5714291
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = Read();
        var W = Read();
        var dp = Enumerable.Repeat(long.MaxValue / 2, 100001).ToArray();
        dp[0] = 0;
        for (int i = 0; i < n; i++)
        {
            var w = Read();
            var v = Read();
            for (int j = dp.Length - v - 1; j >= 0; j--) dp[j + v] = Min(dp[j + v], dp[j] + w);
        }
        for (int i = dp.Length - 1; i >= 0; i--)
            if (dp[i] <= W)
            {
                Console.WriteLine(i);
                return;
            }
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
