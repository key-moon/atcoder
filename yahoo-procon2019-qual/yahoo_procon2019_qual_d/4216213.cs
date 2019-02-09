// detail: https://atcoder.jp/contests/yahoo-procon2019-qual/submissions/4216213
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int L = int.Parse(Console.ReadLine());
        //特定の区間について奇数の増加をもたせられる
        //0がある場合話が変わってくるんだよなあ
        //全区間に対して偶数撒いて、どっかを奇数だけ減らす?
        //偶数撒きをする際は、0を作るべき区間に注意
        //0はコスト2かかる
        //とりあえず0撒いて
        //奇数が
        //端から奇数をまきたい
        //0の向こう側
        int[] a = Enumerable.Repeat(0, L).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        //dp[i][0,1,2,3,4]
        //iまで見た[まだ初めてない,偶数パート1,奇数,偶数パート2,ア]
        long[][] dp = Enumerable.Repeat(0, L).Select(_ => new long[5]).ToArray();
        //0 -> 1,2,3,4
        //1 -> 2,3,4
        //2 -> 3,4
        //3 -> 4


        dp[0][0] = a[0];
        dp[0][1] = a[0] == 0 ? 2 : a[0] % 2;
        dp[0][2] = (a[0] + 1) % 2;
        dp[0][3] = dp[0][1];
        dp[0][4] = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            dp[i][0] = dp[i - 1][0] + a[i];
            dp[i][1] = Min(dp[i - 1][0], dp[i - 1][1]) + (a[i] == 0 ? 2 : a[i] % 2);
            dp[i][2] = Min(Min(dp[i - 1][0], dp[i - 1][1]), dp[i - 1][2]) + (a[i] + 1) % 2;
            dp[i][3] = Min(Min(dp[i - 1][0], dp[i - 1][1]), Min(dp[i - 1][2], dp[i - 1][3])) + (a[i] == 0 ? 2 : a[i] % 2);
            dp[i][4] = Min(Min(Min(dp[i - 1][0], dp[i - 1][1]), Min(dp[i - 1][2], dp[i - 1][3])), dp[i - 1][4]) + a[i];
        }
        Console.WriteLine(dp.Last().Min());
    }
}
