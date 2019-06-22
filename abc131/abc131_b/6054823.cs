// detail: https://atcoder.jp/contests/abc131/submissions/6054823
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
        var nl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nl[0];
        var l = nl[1];
        Console.WriteLine(Enumerable.Range(l, n).Sum() - Enumerable.Range(l, n).OrderBy(Abs).First());
    }
}
