// detail: https://atcoder.jp/contests/abc128/submissions/5632564
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var p = ab[0] * 3 + ab[1];
        Console.WriteLine(p / 2);
    }
}
