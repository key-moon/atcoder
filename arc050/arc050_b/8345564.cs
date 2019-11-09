// detail: https://atcoder.jp/contests/arc050/submissions/8345564
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using static Reader;

public static class P
{
    static long r;
    static long b;
    static long x;
    static long y;
    public static void Main()
    {
        r = NextLong;
        b = NextLong;
        x = NextLong;
        y = NextLong;
        long valid = 0;
        long invalid = long.MaxValue / 2;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            if (CanMake(mid)) valid = mid;  
            else invalid = mid;  
        }
        Console.WriteLine(valid);
    }

    public static bool CanMake(long target)
    {
        if (r < target || b < target) return false;
        if (x == 1 || y == 1) return true;
        return target <= (r - target) / (x - 1) + (b - target) / (y - 1);
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
