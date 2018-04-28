// detail: https://atcoder.jp/contests/agc023/submissions/2427599
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] sum = new long[a.Length + 1];
        sum[0] = a[0];
        sum[a.Length] = 0;
        for (int i = 1; i < a.Length; i++)
        {
            sum[i] = sum[i - 1] + a[i];
        }
        Dictionary<long, long> dict = new Dictionary<long, long>();
        foreach (var i in sum)
        {
            if (!dict.ContainsKey(i)) dict.Add(i, 0);
            dict[i]++;
        }
        Console.WriteLine(dict.Values.Where(x => x >= 2).Sum(x => (x * (x - 1)) / (2 * 1)));
    }
}
