// detail: https://atcoder.jp/contests/abc037/submissions/1932281
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[2] / Math.Min(a[0],a[1]) + (a[2] - (a[2] / Math.Min(a[0], a[1])) * Math.Min(a[0], a[1])) / Math.Max(a[0], a[1]));
    }
}
