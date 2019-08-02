// detail: https://atcoder.jp/contests/otemae2019/submissions/6648680
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
        var n = NextInt;
        var d = NextInt;
        //どこまで移動させたかのDPだろ?ぼくしってる
        long[] dp = Enumerable.Repeat(long.MaxValue, n).ToArray();
        dp[0] = 0;
        for (int i = 0; i < d; i++)
        {
            long min = long.MaxValue;
            long currentSum = 0;
            long allSum = 0;
            long[] coins = new long[n];
            for (int j = 0; j < n; j++)
            {
                allSum += (coins[j] = NextInt);
            }
            for (int j = 0; j < n; j++)
            {
                currentSum += coins[j];
                min = Min(min, dp[j]);
                dp[j] = min + Abs(allSum - currentSum - currentSum);
            }
        }
        Console.WriteLine(dp.Min());
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
