// detail: https://atcoder.jp/contests/pakencamp-2019-day4/submissions/9153460
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
        var l1 = NextInt;
        var r1 = NextInt;
        var l2 = NextInt;
        var r2 = NextInt;
        var all2 = r2 - l2 + 1;
        var l3 = NextInt;
        var r3 = NextInt;
        var all3 = r3 - l3 + 1;
        List<double> probs = new List<double>();
        for (int i = l1; i <= r1; i++)
        {
            double prob2 = (double)Min(Max(0, r2 - i), all2) / all2;
            double prob3 = (double)Min(Max(0, r3 - i), all3) / all3;
            probs.Add(prob2 * prob3);
        }
        Console.WriteLine(probs.Average());
    }
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
