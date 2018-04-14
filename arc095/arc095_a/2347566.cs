// detail: https://atcoder.jp/contests/arc095/submissions/2347566
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sort = x.OrderBy(y => y).ToArray();
        foreach (var item in x)
        {
            if (sort[n / 2] <= item) Console.WriteLine(sort[(n / 2) - 1]);
            else Console.WriteLine(sort[n / 2]);
        }
    }
}
