// detail: https://atcoder.jp/contests/abc132/submissions/6161487
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var d = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var under = d.Take(n / 2).Last();
        var upper = d.Skip(n / 2).First();
        Console.WriteLine(upper - under);
    }
}
