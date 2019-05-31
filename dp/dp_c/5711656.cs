// detail: https://atcoder.jp/contests/dp/submissions/5711656
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

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        int[] dp = new int[3];
        for (int i = 0; i < n; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            dp = new int[]
            {
                abc[0] + Max(dp[1], dp[2]),
                abc[1] + Max(dp[0], dp[2]),
                abc[2] + Max(dp[0], dp[1])
            };
        }
        Console.WriteLine(dp.Max());
    }
}
