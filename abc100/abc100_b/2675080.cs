// detail: https://atcoder.jp/contests/abc100/submissions/2675080
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] p = {1, 100, 10000, 1000000 };
        int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(p[ab[0]] * (ab[1] + ab[1] / 100));
    }
}
