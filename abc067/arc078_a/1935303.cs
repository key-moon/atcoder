// detail: https://atcoder.jp/contests/abc067/submissions/1935303
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long asum = a.Sum();
        long[] sum = new long[a.Length - 1];
        sum[0] = a[0];
        for (int i = 1; i < sum.Length; i++)
        {
            sum[i] = sum[i - 1] + a[i];
        }
        long res = long.MaxValue;
        foreach (var i in sum)
        {
            res = Math.Min(res, Math.Abs(asum - i * 2));
        }
        Console.WriteLine(res);
    }
}
