// detail: https://atcoder.jp/contests/otemae2019/submissions/6647767
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] count = b.Aggregate(new int[100001], (x, y) => { x[y]++; return x; });
        int[] currentCount = new int[100001];
        int min = int.MaxValue;
        for (int i = 0; i < a.Length; i++)
        {
            currentCount[a[i]]++;
            min = Min(min, count[a[i]] / currentCount[a[i]]);
            Console.WriteLine(min);
        }
    }
}
