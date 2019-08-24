// detail: https://atcoder.jp/contests/abc062/submissions/7106826
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var h = NextInt;
        var w = NextInt;
        Console.WriteLine(Min(Solve(h, w), Solve(w, h)));
    }

    static long Solve(long h, long w)
    {
        var min = w % 3 == 0 ? 0 : w >= 3 ? h : long.MaxValue;
        for (int i = 1; i < h; i++)
        {
            var pieces = new long[] { w * i, (h - i) * (w / 2), (h - i) * (w - w / 2) };
            min = Min(min, pieces.Max() - pieces.Min());
        }
        return min;
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
