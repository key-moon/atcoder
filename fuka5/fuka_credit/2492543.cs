// detail: https://atcoder.jp/contests/fuka5/submissions/2492543
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        while (true)
        {
            int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (nk[0] == 0) break;
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(a => a).Take(nk[1]).Sum());
        }
    }
}
