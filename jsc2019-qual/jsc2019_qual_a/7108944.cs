// detail: https://atcoder.jp/contests/jsc2019-qual/submissions/7108944
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
        var M = NextInt;
        var D = NextInt;
        var c = 0;
        for (int m = 1; m <= M; m++)
        {
            for (int d = 1; d <= D; d++)
            {
                var d1 = d % 10;
                var d10 = d / 10;
                if (2 <= d1 && 2 <= d10 && d1 * d10 == m) c++;
            }
        }
        Console.WriteLine(c);
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
