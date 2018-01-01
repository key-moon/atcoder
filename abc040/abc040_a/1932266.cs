// detail: https://atcoder.jp/contests/abc040/submissions/1932266
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Math.Min(a[0] - a[1] , a[1] -  1));
    }
}
