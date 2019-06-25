// detail: https://atcoder.jp/contests/joi2018yo/submissions/6122107
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).Aggregate(new Tuple<int, int>(0, 0), (x, y) => new Tuple<int, int>(y == 1 ? x.Item1 + 1 : 0, Max(x.Item2, x.Item1)));
        Console.WriteLine(Max(a.Item1, a.Item2) + 1);
    }
}
