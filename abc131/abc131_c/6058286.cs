// detail: https://atcoder.jp/contests/abc131/submissions/6058286
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
        var a = NextLong;
        var b = NextLong;
        var c = NextLong;
        var d = NextLong;
        var cdiv = GetCount(a, b, c);
        var ddiv = GetCount(a, b, d);
        var bothdiv = GetCount(a, b, c * d);
        Console.WriteLine((b - a + 1) - GetCount(a, b, c) - GetCount(a, b, d) + GetCount(a, b, LCM(c, d)));
    }
    static long GetCount(long min, long max, long div) => (max / div) - ((min - 1) / div);


    static long LCM(long a, long b) => a / GCD(a, b) * b;
    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }

    static readonly TextReader In = Console.In;
    static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0;
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
