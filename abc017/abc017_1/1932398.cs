// detail: https://atcoder.jp/contests/abc017/submissions/1932398
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int res = 0;
        for (int i = 0; i < 3; i++)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            res += a[0] * a[1] / 10;
        }
        Console.WriteLine(res);
    }
}
