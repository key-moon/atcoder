// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/9929076
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var dishes = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderByDescending(x => x.Sum()).ToArray();
        Console.WriteLine(dishes.Where((_, ind) => ind % 2 == 0).Sum(x => x[0]) - dishes.Where((_, ind) => ind % 2 == 1).Sum(x => x[1]));
    }
}
