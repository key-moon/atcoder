// detail: https://atcoder.jp/contests/apc001/submissions/2051272
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res = -1;
        if (a[0] % a[1] == 0) res = -1;
        else res = (a[1] - 1) * a[0];
        Console.WriteLine(res);
    }
}
