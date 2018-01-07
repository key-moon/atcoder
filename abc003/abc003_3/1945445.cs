// detail: https://atcoder.jp/contests/abc003/submissions/1945445
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).Skip(nk[0] - nk[1]).ToArray();
        double d = 0;
        foreach (var i in a)
        {
            d = (d + i) / 2;
        }
        Console.WriteLine(d);
    }
}
