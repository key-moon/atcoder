// detail: https://atcoder.jp/contests/abc120/submissions/4447763
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        var abk = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Enumerable.Range(1, 1000).Reverse().Where(x => (abk[0] % x == 0) && (abk[1] % x == 0)).Skip(abk[2] - 1).First());
    }
}
