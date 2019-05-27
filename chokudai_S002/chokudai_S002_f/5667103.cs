// detail: https://atcoder.jp/contests/chokudai_S002/submissions/5667103
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = Read();
        List<long> set = new List<long>();
        for (int i = 0; i < n; i++)
        {
            var a = Read();
            var b = Read();
            set.Add((Max(a, b) << 32) + Min(a, b));
        }
        Console.WriteLine(set.OrderBy(x => x).Aggregate(new { last = -1L, count = 0 } , (x, y) => new { last = y, count = x.last != y ? x.count + 1 : x.count }).count);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Read()
    {
        long res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
