// detail: https://atcoder.jp/contests/abc054/submissions/1931430
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (a[0] == 1)
        {
            a[0] = 1212;
        }
        if (a[1] == 1)
        {
            a[1] = 1212;
        }
        Console.WriteLine(a[0] == a[1] ? "Draw" : (a[0] < a[1] ?"Bob":"Alice"));
    }
}
