// detail: https://atcoder.jp/contests/arc091/submissions/2184311
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        //奇数が裏
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res = 0;
        if (a[0] == 1 && a[1] == 1)
        {
            res = 1;
        }
        else if (a[0] == 1)
        {
            res = a[1] - 2;
        }
        else if (a[1] == 1)
        {
            res = a[0] - 2;
        }
        else
        {
            res = (a[0] - 2) * (a[1] - 2);
        }
        Console.WriteLine(res);
    }
}
