// detail: https://atcoder.jp/contests/abc128/submissions/9548995
using System;
using System.Linq;
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int i = 1; i < n / 2; i++)
        {
            var max = (n - 1) % i == 0 ? n / 2 : n - i;
            var cur = 0L;
            for (int j = 0; j < max; j += i)
                res = Max(res, cur += a[j] + a[n - 1 - j]);
        }
        Console.WriteLine(res);
    }
}
