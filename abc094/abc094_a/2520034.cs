// detail: https://atcoder.jp/contests/abc094/submissions/2520034
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] abx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(abx[0]<=abx[2]&&abx[1]+ abx[0] >= abx[2] ? "YES":"NO");
    }
}
