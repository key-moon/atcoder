// detail: https://atcoder.jp/contests/abc139/submissions/7804670
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
        int n = Reader.NextUInt;
        int last = 0;
        int cur = 0;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            var h = Reader.NextUInt;
            if (last >= h) max = Max(max, ++cur);
            else cur = 0;
            last = h;
        }
        Console.WriteLine(max);
    }
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] buffer = new byte[BUF_SIZE];
    static int ptr = 0;

    private static void Read() { Stream.Read(buffer, 0, BUF_SIZE); }

    private static byte Next { get { if (ptr >= buffer.Length) { Read(); ptr = 0; } return buffer[ptr++]; } }

    public static int NextUInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; byte next; do { next = Next; } while (next < 48);
            do { res = res * 10 + (next ^ 48); next = Next; } while (48 <= next);
            return res;
        }
    }

    public static long NextULong
    {
        get
        {
            long res = 0; byte next; do { next = Next; } while (next < 48);
            do { res = res * 10 + next - 48; next = Next; } while (48 <= next);
            return res;
        }
    }
}
