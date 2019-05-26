// detail: https://atcoder.jp/contests/abc128/submissions/5635165
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
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("
", Enumerable.Range(0, n).Select(x => new Tuple<int, string[]>(x + 1, Console.ReadLine().Split())).OrderBy(x => x.Item2[0]).ThenByDescending(x => int.Parse(x.Item2[1])).Select(x => x.Item1)));
    }
}
