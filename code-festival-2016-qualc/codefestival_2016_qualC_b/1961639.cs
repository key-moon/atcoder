// detail: https://atcoder.jp/contests/code-festival-2016-qualc/submissions/1961639
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int i = Console.ReadLine().Split().Select(int.Parse).ToArray()[0];
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int amax = A.Max();
        Console.WriteLine(Math.Max(amax - (i - amax) - 1, 0));
    }
}
