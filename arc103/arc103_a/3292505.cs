// detail: https://atcoder.jp/contests/arc103/submissions/3292505
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] v = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> d1 = new Dictionary<int, int>();
        Dictionary<int, int> d2 = new Dictionary<int, int>();
        List<int> v1 = new List<int>();
        List<int> v2 = new List<int>();
        for (int i = 0; i < v.Length; i++)
        {
            var d = i % 2 == 0 ? d1 : d2;
            if (!d.ContainsKey(v[i])) d.Add(v[i], 0);
            d[v[i]]++;
        }
        var sorted1 = d1.OrderByDescending(x => x.Value).ToList();
        var sorted2 = d2.OrderByDescending(x => x.Value).ToList();
        sorted1.Add(new KeyValuePair<int, int>(-1, 0));
        sorted2.Add(new KeyValuePair<int, int>(-1, 0));
        var count = sorted1[0].Value + sorted2[0].Value;
        if (sorted1[0].Key == sorted2[0].Key)
        {
            count = Max(sorted1[0].Value + sorted2[1].Value, sorted1[1].Value + sorted2[0].Value);
        }
        Console.WriteLine(n - count);
    }
}
