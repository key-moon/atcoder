// detail: https://atcoder.jp/contests/abc146/submissions/8621887
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using static Reader;

public static class P
{
    public static void Main()
    {
        long n, k;
        long[] a;
        n = NextLong;
        k = NextLong;
        a = Enumerable.Repeat(0, (int)n).Select(_ => NextLong - 1).ToArray();
        
        var accum = new long[n + 1];
        for (int i = 1; i < accum.Length; i++)
            accum[i] = (accum[i - 1] + a[i - 1]) % k;
        long res = 0;
        Dictionary<long, long> count = accum.Distinct().ToDictionary(x => x, _ => 0L);
        var max = Min(k, accum.Length);
        for (int i = 0; i < max; i++)
        {
            res += count[accum[i]];
            count[accum[i]]++;
        }
        for (int i = (int)max; i < accum.Length; i++)
        {
            count[accum[i - k]]--;
            res += count[accum[i]];
            count[accum[i]]++;
        }
        Console.WriteLine(res);
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
