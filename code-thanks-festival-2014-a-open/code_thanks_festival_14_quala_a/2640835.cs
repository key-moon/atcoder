// detail: https://atcoder.jp/contests/code-thanks-festival-2014-a-open/submissions/2640835
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a[0] * 4 + a[1] * 2);
    }
}
