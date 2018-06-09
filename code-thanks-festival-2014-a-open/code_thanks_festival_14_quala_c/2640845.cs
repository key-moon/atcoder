// detail: https://atcoder.jp/contests/code-thanks-festival-2014-a-open/submissions/2640845
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Sum(x => p[x - 1]));
    }
}
