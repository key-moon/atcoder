// detail: https://atcoder.jp/contests/abc039/submissions/1932268
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((a[0] * a[1] + a[1] * a[2] + a[2] * a[0]) * 2);
    }
}
