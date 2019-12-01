// detail: https://atcoder.jp/contests/sumitrust2019/submissions/8738787
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
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var t1 = NextLong;
        var t2 = NextLong;
        var a1 = NextLong;
        var a2 = NextLong;
        var b1 = NextLong;
        var b2 = NextLong;
        var alast = a1 * t1 + a2 * t2;
        var blast = b1 * t1 + b2 * t2;
        if (alast == blast)
        {
            Console.WriteLine("infinity");
            return;
        }

        if (blast > alast)
        {
            var tmp1 = a1;
            var tmp2 = a2;
            a1 = b1;
            a2 = b2;
            b1 = tmp1;
            b2 = tmp2;
        }

        var max = Max(alast, blast);
        var abs = Abs(alast - blast);
        var valid = -1L;
        var invalid = max / abs + 10;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            var diff = abs * mid;
            if (diff + a1 * t1 <= b1 * t1) valid = mid;
            else invalid = mid;
        }
        var res = valid * 2 + 1;
        if (abs * valid + a1 * t1 == b1 * t1) res--;
        Console.WriteLine(Max(0, res));
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = 0;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (long)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
