// detail: https://atcoder.jp/contests/code-thanks-festival-2015-open/submissions/6390072
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var c = int.Parse(Console.ReadLine());
        List<int> cand = new List<int>();
        if (a[0] == c || a[1] == c)
            cand.AddRange(b);
        if (b[0] == c || b[1] == c)
            cand.AddRange(a);
        cand = cand.Distinct().OrderBy(x => x).ToList();
        Console.WriteLine(cand.Count);
        Console.WriteLine(string.Join("
", cand));
    }
}
