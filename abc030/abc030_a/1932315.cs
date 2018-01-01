// detail: https://atcoder.jp/contests/abc030/submissions/1932315
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[0] * a[3] == a[1] * a[2] ? "DRAW" :(a[0] * a[3] > a[1] * a[2] ? "AOKI" : "TAKAHASHI"));
    }
}
