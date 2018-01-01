// detail: https://atcoder.jp/contests/abc031/submissions/1932312
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Max((a[0] * (a[1] + 1)), ((a[0] + 1) * a[1])));
    }
}
