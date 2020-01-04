// detail: https://atcoder.jp/contests/arc092/submissions/9311029
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
        int n = NextInt;
        Point[] red = Enumerable.Range(0, n).Select(_ => new Point() { Y = NextInt, X = NextInt }).OrderBy(x => x.X).ToArray();
        List<Point> blue = Enumerable.Range(0, n).Select(_ => new Point() { Y = NextInt, X = NextInt }).OrderBy(x => x.X).ToList();
        var res = 0;
        for (int i = red.Length - 1; i >= 0; i--)
        {
            var cands = blue.Where(x => red[i].X < x.X && red[i].Y < x.Y).ToArray();
            if (cands.Length == 0) continue;
            var pair = cands.OrderBy(x => x.Y).First();
            blue.Remove(pair);
            res++;
        }
        Console.WriteLine(res);
    }
}

class Point
{
    public int Y;
    public int X;
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
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
