// detail: https://atcoder.jp/contests/abc060/submissions/8134362
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
        var n = Reader.NextInt;
        var W = Reader.NextInt;
        Dictionary<long, long> values = new Dictionary<long, long>();
        values.Add(0, 0);
        for (int i = 0; i < n; i++)
        {
            var w = Reader.NextInt;
            var v = Reader.NextInt;
            var newValues = new Dictionary<long, long>();
            foreach (var item in values)
            {
                if (!newValues.TryAdd(item.Key, item.Value)) newValues[item.Key] = Max(newValues[item.Key], item.Value);
                if (W < item.Key + w) continue;
                if (!newValues.TryAdd(item.Key + w, item.Value + v)) newValues[item.Key + w] = Max(newValues[item.Key + w], item.Value + v);
            }
            values = newValues;
        }
        Console.WriteLine(values.Values.Max());
    }

    static bool TryAdd<T1, T2>(this Dictionary<T1, T2> dic, T1 key, T2 value)
    {
        if (dic.ContainsKey(key)) return false;
        dic.Add(key, value);
        return true;
    }
}

struct Object
{
    public int Weight;
    public long Value;
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
