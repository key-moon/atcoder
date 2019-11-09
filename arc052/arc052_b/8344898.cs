// detail: https://atcoder.jp/contests/arc052/submissions/8344898
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
    public static void Main()
    {
        var n = NextInt;
        var q = NextInt;
        Corn[] corns = Enumerable.Repeat(0, n).Select(_ => new Corn() { X = NextInt, R = NextInt, H = NextInt }).ToArray();
        for (int i = 0; i < q; i++)
        {
            var a = NextInt;
            var b = NextInt;
            Console.WriteLine(corns.Sum(x => x.GetArea(a, b)));
        }
    }
}

struct Corn
{
    public int X;
    public int R;
    public int H;
    public double GetArea(int X1, int X2)
    {
        X1 = Max(X, X1);
        X2 = Min(X + H, X2);
        if (X1 > X2) return 0;
        double X1Radius = (H - (double)(X1 - X)) / H * R;
        double X2Radius = (H - (double)(X2 - X)) / H * R;
        return (X1Radius * X1Radius + X1Radius * X2Radius + X2Radius * X2Radius) * (X2 - X1) * PI / 3;
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
