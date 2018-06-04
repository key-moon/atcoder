// detail: https://atcoder.jp/contests/abc068/submissions/2616746
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] b = Enumerable.Repeat(0, nm[0]).Select(x => new bool[2]).ToArray();
        b[0][0] = true;
        b[b.Length - 1][1] = true;
        for (int i = 0; i < nm[1]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
            if (ab[0] == 1) b[ab[1] - 1][0] = true;
            if (ab[1] == nm[0]) b[ab[0] - 1][1] = true;
        }
        Console.WriteLine(b.Any(x => x[0] && x[1]) ? "POSSIBLE" : "IMPOSSIBLE");
    }
}
