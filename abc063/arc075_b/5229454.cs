// detail: https://atcoder.jp/contests/abc063/submissions/5229454
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nab[0];
        long a = nab[1] - nab[2];
        long b = nab[2];
        var h = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).ToArray();
        int valid = int.MaxValue / 2;
        int invalid = 0;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (h.Sum(x => (Max(0, x - b * mid) + a - 1) / a) <= mid) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}
