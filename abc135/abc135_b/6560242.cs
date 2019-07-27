// detail: https://atcoder.jp/contests/abc135/submissions/6560242
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
        Console.WriteLine(Enumerable.Range(1, n).Zip(Console.ReadLine().Split().Select(int.Parse).ToArray(), (x, y) => x != y).Count(x => x) <= 2 ? "YES" : "NO");
    }
}
