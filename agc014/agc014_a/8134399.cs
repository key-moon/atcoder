// detail: https://atcoder.jp/contests/agc014/submissions/8134399
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int res = 0;
        var a = Reader.NextLong;
        var b = Reader.NextLong;
        var c = Reader.NextLong;
        if ((a & 1) + (b & 1) + (c & 1) == 0 && a == b && b == c)
        {
            Console.WriteLine(-1);
            return;
        }
        while ((a & 1) + (b & 1) + (c & 1) == 0)
        {
            var newa = (b >> 1) + (c >> 1);
            var newb = (a >> 1) + (c >> 1);
            var newc = (a >> 1) + (b >> 1);
            a = newa;
            b = newb;
            c = newc;
            res++;
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
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
