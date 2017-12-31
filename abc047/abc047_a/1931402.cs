// detail: https://atcoder.jp/contests/abc047/submissions/1931402
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine((a[0] + a[1] == a[2] || a[0] + a[2] == a[1] || a[1] + a[2] == a[0]) ? "Yes" : "No");
    }
}
