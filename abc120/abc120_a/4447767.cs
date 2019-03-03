// detail: https://atcoder.jp/contests/abc120/submissions/4447767
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Min(abc[1] / abc[0], abc[2]));
    }
}
