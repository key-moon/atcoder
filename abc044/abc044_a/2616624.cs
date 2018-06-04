// detail: https://atcoder.jp/contests/abc044/submissions/2616624
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nkxy = Enumerable.Repeat(0, 4).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        Console.WriteLine(Min(nkxy[0], nkxy[1]) * nkxy[2] + Max(0, nkxy[0] - nkxy[1]) * nkxy[3]);
    }
}
