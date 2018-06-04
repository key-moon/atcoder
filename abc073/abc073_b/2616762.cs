// detail: https://atcoder.jp/contests/abc073/submissions/2616762
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
        int[][] lr = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        Console.WriteLine(lr.Sum(x => x[1] - x[0] + 1));
    }
}
