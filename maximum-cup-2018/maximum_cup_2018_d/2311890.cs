// detail: https://atcoder.jp/contests/maximum-cup-2018/submissions/2311890
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nmlk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] dp = Enumerable.Repeat(int.MaxValue / 2, nmlk[1]).ToArray();
        dp[0] = 0;
        foreach (var item in a)
        {
            int[] newDP = Enumerable.Repeat(int.MaxValue / 2, nmlk[1]).ToArray();
            for (int i = 0; i < dp.Length; i++)
            {
                newDP[(i + item) % dp.Length] = Min(dp[(i + item) % dp.Length], (dp[i] + (i + item) / dp.Length));
                
            }
            dp = newDP;
        }
        if(dp[nmlk[2]] < nmlk[3])
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
