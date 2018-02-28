// detail: https://atcoder.jp/contests/abc040/submissions/2142771
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] dp = Enumerable.Repeat(int.MaxValue, n).ToArray();
        dp[0] = 0;
        for (int i = 0; i < a.Length - 2; i++)
        {
            dp[i + 1] = Math.Min(dp[i + 1], dp[i] + Math.Abs(a[i] - a[i + 1]));
            dp[i + 2] = Math.Min(dp[i + 2], dp[i] + Math.Abs(a[i] - a[i + 2]));
        }
        Console.WriteLine(Math.Min(dp[a.Length - 1], dp[a.Length - 2] + Math.Abs(a[a.Length - 2] - a[a.Length - 1])));
    }
}
