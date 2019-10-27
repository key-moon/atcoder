// detail: https://atcoder.jp/contests/abc041/submissions/8183566
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = Reader.NextInt;
        var m = Reader.NextInt;

        int[] dependOn = new int[n];
        for (int i = 0; i < m; i++)
        {
            var x = Reader.NextInt - 1;
            var y = Reader.NextInt - 1;
            dependOn[y] |= 1 << x;
        }

        long[] perms = new long[1 << n];
        perms[0] = 1;
        for (int i = 0; i < perms.Length; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //いままである or 依存関係が解決されてない→だめ
                if ((i >> j & 1) != 0 || (dependOn[j] & i) != dependOn[j]) continue;
                perms[i | (1 << j)] += perms[i];
            }
        }
        Console.WriteLine(perms[(1 << n) - 1]);
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
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
