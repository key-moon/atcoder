// detail: https://atcoder.jp/contests/arc075/submissions/9912778
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nab[0];
        var a = nab[1] - nab[2];
        var b = nab[2];
        var h = Enumerable.Repeat(0, (int)n).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();
        long valid = int.MaxValue;
        long invalid = 0;
        while ((valid - invalid) > 1)
        {
            var mid = (valid + invalid) / 2;
            if (h.Select(x => (Max(x - b * mid, 0) + a - 1) / a).Sum() <= mid) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}
