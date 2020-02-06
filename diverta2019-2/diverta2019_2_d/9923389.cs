// detail: https://atcoder.jp/contests/diverta2019-2/submissions/9923389
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Action<long[], int, int> updateDP = (dp, buyPrice, sellPrice) =>
        {
            if (buyPrice > sellPrice) return;
            var benefit = sellPrice - buyPrice;
            for (int i = buyPrice; i < dp.Length; i++)
            {
                dp[i] = Max(dp[i], dp[i - buyPrice] + benefit);
            }
        };

        {
            //どんぐりi個を換金した時に得られる最大利益
            var dp = new long[n + 1];
            updateDP(dp, a[0], b[0]);
            updateDP(dp, a[1], b[1]);
            updateDP(dp, a[2], b[2]);
            n = n + (int)dp.Max();
        }

        {
            //どんぐりi個を換金した時に得られる最大利益
            var dp = new long[n + 1];
            updateDP(dp, b[0], a[0]);
            updateDP(dp, b[1], a[1]);
            updateDP(dp, b[2], a[2]);
            Console.WriteLine(n + dp.Max());
        }
    }
}
