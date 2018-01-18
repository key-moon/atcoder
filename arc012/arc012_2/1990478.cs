// detail: https://atcoder.jp/contests/arc012/submissions/1990478
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double diff = a[3];
        for (int i = 0; i < a[0]; i++)
        {
            diff = (diff / a[1]) * a[2];
        }
        Console.WriteLine(diff);
    }
}
