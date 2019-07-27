// detail: https://atcoder.jp/contests/abc135/submissions/6560872
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(ab.Sum() % 2 == 0 ? (ab.Sum() / 2).ToString() : "IMPOSSIBLE");
    }
}
