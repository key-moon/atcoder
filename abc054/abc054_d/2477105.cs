// detail: https://atcoder.jp/contests/abc054/submissions/2477105
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nmm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] abcs = Enumerable.Repeat(0, nmm[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        //Cには混合比がM:M
        //Ag、Bg作るのに必要な最小価格
        //10gが40個→400g*400gのテーブル(160000)*40回
        int[][] dp = Enumerable.Repeat(0, 401).Select(x => Enumerable.Repeat(int.MaxValue / 2, 401).ToArray()).ToArray();
        dp[0][0] = 0;
        for (int p = 0; p < abcs.Length; p++)
        {
            int[] item = abcs[p];
            int[][] newdp = Enumerable.Repeat(0, 401).Select(x => Enumerable.Repeat(int.MaxValue / 2, 401).ToArray()).ToArray();
            for (int i = 0; i < 401; i++)
            {
                for (int j = 0; j < 401; j++)
                {
                    if (i < item[0] || j < item[1]) newdp[i][j] = dp[i][j];
                    else newdp[i][j] = Min(dp[i - item[0]][j - item[1]] + item[2], dp[i][j]);
                }
            }
            dp = newdp;
        }
        int min = int.MaxValue;
        int m1 = nmm[1];
        int m2 = nmm[2];
        for (int i = 1; m1 * i < 401 && m2 * i < 401; i++)
        {
            min = Min(min, dp[m1 * i][m2 * i]);
        }
        Debug.WriteLine(string.Join("
", dp.Select(x => string.Join(" ", x.Select(y => y != int.MaxValue / 2 ? "o" : "x")))));
        if (min == int.MaxValue / 2) min = -1;
        Console.WriteLine(min);
    } 
}
