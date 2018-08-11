// detail: https://atcoder.jp/contests/abc105/submissions/2986120
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1];
        //累積取って、余りの個数
        Dictionary<long, long> dict = new Dictionary<long, long>();
        dict.Add(0, 1);
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long ruiseki = 0;
        for (int i = 0; i < n; i++)
        {
            ruiseki += a[i];
            if (!dict.ContainsKey(ruiseki % m))
            {
                dict.Add(ruiseki % m, 0);
            }
            dict[ruiseki % m]++;
        }
        long res = 0;
        foreach (var val in dict.Values)
        {
            res += (val - 1) * val;
        }
        Console.WriteLine(res / 2);
    }
}
