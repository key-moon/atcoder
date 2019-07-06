// detail: https://atcoder.jp/contests/bcu30-2019/submissions/6257028
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Repeat(0, nk[0]).Select(_ => int.Parse(Console.ReadLine())).OrderByDescending(x => x).ToArray();
        Console.WriteLine(a.Take(nk[1]).Sum() + a.Skip(nk[1]).Sum() * 2);
    }
}
