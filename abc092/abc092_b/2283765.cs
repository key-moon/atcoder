// detail: https://atcoder.jp/contests/abc092/submissions/2283765
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] dx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).Sum(x => (dx[0] - 1) / x) + dx[1] + n);
    }
}
