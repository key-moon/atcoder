// detail: https://atcoder.jp/contests/abc152/submissions/9605580
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
        int n = int.Parse(Console.ReadLine());
        int[][] count = Enumerable.Repeat(0, 10).Select(_ => new int[10]).ToArray();
        for (int i = 1; i <= n; i++)
        {
            var a = i.ToString();
            count[a.First() - '0'][a.Last() - '0']++;
        }
        long res = 0;
        for (int i = 1; i <= n; i++)
        {
            var b = i.ToString();
            res += count[b.Last() - '0'][b.First() - '0'];
        }
        Console.WriteLine(res);
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
