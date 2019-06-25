// detail: https://atcoder.jp/contests/joisc2007/submissions/6122297
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
        var rank = 1;
        Console.WriteLine(string.Join("
", Enumerable.Range(0, n).Select(x => new { Score = int.Parse(Console.ReadLine()), Index = x }).GroupBy(x => x.Score).OrderByDescending(x => x.Key).SelectMany(x => { var tmp = x.Select(y => new { y.Index, Rank = rank }).ToArray(); rank += x.Count(); return tmp; }).OrderBy(x => x.Index).Select(x => x.Rank)));
    }
}
