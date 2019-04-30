// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5195913
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;

static class P
{
    static void Main()
    {
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[,] dp = new long[nmk[1] + 1, nmk[2]];
        for (int i = 0; i < nmk[1] + 1; i++)
        {
            for (int j = 0; j < nmk[2]; j++)
            {
                dp[i, j] = -1;
            }
        }
        dp[0, 0] = 0;
        for (int index = 0; index < a.Length; index++)
        {
            var elem = a[index];
            long[,] newdp = new long[nmk[1] + 1, nmk[2]];
            for (int i = 0; i < nmk[1] + 1; i++)
            {
                for (int j = 0; j < nmk[2]; j++)
                {
                    newdp[i, j] = -1;
                }
            }
            for (int i = 0; i < nmk[1] + 1; i++)
            {
                for (int j = 0; j < nmk[2]; j++)
                {
                    if (dp[i, j] == -1) continue;
                    if (j + 1 < nmk[2]) newdp[i, j + 1] = Max(newdp[i, j + 1], dp[i, j]);
                    if (i + 1 < nmk[1] + 1) newdp[i + 1, 0] = Max(newdp[i + 1, 0], dp[i, j] + elem);
                }
            }
            dp = newdp;
        }
        long res = -1;
        for (long i = 0; i < nmk[2]; i++) res = Max(res, dp[nmk[1], i]);
        Console.WriteLine(res);


    }
}
