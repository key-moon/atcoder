// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/8134408
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
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = nab[1];
        var b = nab[2];
        var total = a + b;
        var current = 0;
        var bCount = 0;
        foreach (var c in Console.ReadLine())
        {
            if (c == 'a') if (current >= total) goto end;
            if (c == 'b') if (current >= total || bCount >= b) goto end; else bCount++;
            if (c == 'c') goto end;
            Console.WriteLine("Yes");
            current++;
            continue;
            end:;
            Console.WriteLine("No");
        }
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
