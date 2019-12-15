// detail: https://atcoder.jp/contests/abc071/submissions/8961338
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var cand1 = a.GroupBy(x => x).Where(x => x.Count() >= 2).Select(x => x.Key).OrderByDescending(x => x).Take(2).ToArray();
        var cand2 = a.GroupBy(x => x).Where(x => x.Count() >= 4).Select(x => x.Key).OrderByDescending(x => x).Take(1).ToArray();
        var res = 0L;
        if (cand2.Length >= 1) res = Max(res, cand2[0] * cand2[0]);
        if (cand1.Length >= 2) res = Max(res, cand1[0] * cand1[1]);
        Console.WriteLine(res);
    }
}
