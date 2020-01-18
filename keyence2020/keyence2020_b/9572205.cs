// detail: https://atcoder.jp/contests/keyence2020/submissions/9572205
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
        var n = int.Parse(Console.ReadLine());
        var sections = Enumerable.Repeat(0, n).Select(_ =>
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Tuple<int, int>(a[0] - a[1], a[0] + a[1]);
        }).OrderBy(x => x.Item2).ToArray();
        int res = 0;
        var last = int.MinValue;
        foreach (var section in sections)
        {
            if (last <= section.Item1)
            {
                res++;
                last = section.Item2;
            }
        }
        Console.WriteLine(res);
    }
}
