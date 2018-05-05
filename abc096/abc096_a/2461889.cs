// detail: https://atcoder.jp/contests/abc096/submissions/2461889
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int count = 0;
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        DateTime d = new DateTime(2000, a[0], a[1]);
        for (int i = 1; i <= 12; i++)
        {
            if (new DateTime(2000, i, i) <= d) count++;
        }
        Console.WriteLine(count);
    }
}
