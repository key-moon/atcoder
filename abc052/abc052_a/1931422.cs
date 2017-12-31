// detail: https://atcoder.jp/contests/abc052/submissions/1931422
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(Math.Max(a[0] * a[1], a[2] * a[3]));
    }
}
