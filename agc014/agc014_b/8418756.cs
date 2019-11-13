// detail: https://atcoder.jp/contests/agc014/submissions/8418756
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
using static Reader;

public static class P
{
    public static void Main()
    {
        var n = NextInt;
        var m = NextInt;
        int[] imos = new int[n + 1];
        for (int i = 0; i < m; i++)
        {
            var a = NextInt;
            var b = NextInt;
            imos[Min(a, b) - 1]++;
            imos[Max(a, b) - 1]--;
        }
        int[] accum = new int[n + 1];
        accum[0] = imos[0];
        for (int i = 1; i < accum.Length; i++)
        {
            accum[i] = accum[i - 1] + imos[i];
        }
        Console.WriteLine(accum.All(x => x % 2 == 0) ? "YES" : "NO");
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = 0;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
