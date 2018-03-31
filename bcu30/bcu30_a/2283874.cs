// detail: https://atcoder.jp/contests/bcu30/submissions/2283874
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int now = 0;
        for (int i = 0; i < a.Length; i++)
        {
            now = now + a[i];
            if (now > nk[0]) now = 2 * nk[0] - now;
            if (now == nk[0]) break;
        }
        Console.WriteLine(now);
    }
}
