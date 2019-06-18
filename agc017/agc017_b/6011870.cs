// detail: https://atcoder.jp/contests/agc017/submissions/6011870
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
        long a = Read();
        long b = Read();
        long c = Read();
        long d = Read();

        //   987654321098765432101234567890123456789
        //1 :                   |
        //2 :             -|         |-
        //3 :       --|        -|-        |--
        //4 : ---|       --|-       -|--       |--- 
        var diff = Abs(b - a);
        
        var cand1 = (diff + ((n + 1) % 2) * c) / (c * 2) * 2 - ((n + 1) % 2);
        var cand2 = cand1 + 2;
        var cand3 = n - 1;

        var cand1Margin = (((n - 1) + cand1) / 2);
        var cand2Margin = (n - 2) - cand1Margin;
        var cand3Margin = n - 1;
        Console.WriteLine(
            (cand1 <= (n - 1) && diff <= cand1 * c + cand1Margin * (d - c)) || 
            (cand2 <= (n - 1) && cand2 * c - cand2Margin * (d - c) <= diff) ||
            (cand3 * c <= diff && diff <= cand3 * c + cand3Margin * (d - c)) ? "YES" : "NO");
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
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
