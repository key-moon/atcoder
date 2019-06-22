// detail: https://atcoder.jp/contests/joi2007yo/submissions/6048377
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
        var a = NextInt;
        var b = NextInt;
        var c = NextInt;
        var n = NextInt;
        int[] verdict = Enumerable.Repeat(2, a + b + c).ToArray();
        foreach (var test in Enumerable.Repeat(0, n).Select(_ => new { a = NextInt, b = NextInt, c = NextInt, r = NextInt }).OrderByDescending(x => x.r))
        {
            if (test.r == 1)
            {
                verdict[test.a - 1] = 1;
                verdict[test.b - 1] = 1;
                verdict[test.c - 1] = 1;
            }
            else
            {
                if (verdict[test.a - 1] == 1 && verdict[test.b - 1] == 1) verdict[test.c - 1] = 0;
                if (verdict[test.a - 1] == 1 && verdict[test.c - 1] == 1) verdict[test.b - 1] = 0;
                if (verdict[test.b - 1] == 1 && verdict[test.c - 1] == 1) verdict[test.a - 1] = 0;
            }
        }
        Console.WriteLine(string.Join("
", verdict));
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
            if (next == 45) rev = -1;
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
