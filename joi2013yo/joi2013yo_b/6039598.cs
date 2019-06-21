// detail: https://atcoder.jp/contests/joi2013yo/submissions/6039598
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
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var valid = Enumerable.Range(0, 3).Select(x => a.GroupBy(y => y[x]).Where(y => y.Count() == 1).Select(y => y.Key).ToArray()).ToArray();
        Console.WriteLine(string.Join("
", a.Select(x => x.Where((elem, index) => valid[index].Contains(elem)).Sum())));
    }
}
