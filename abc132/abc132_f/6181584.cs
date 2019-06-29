// detail: https://atcoder.jp/contests/abc132/submissions/6181584
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        List<Chunk> chunks = new List<Chunk>();
        for (int i = 1; i <= n; i++)
        {
            var currentUp = n / i;

            int valid = i;
            int invalid = n + 1;
            while (invalid - valid > 1)
            {
                var mid = (invalid + valid) / 2;
                if (n / mid == currentUp) valid = mid;
                else invalid = mid;
            }
            var count = valid - i + 1;
            var chunk = new Chunk(i, valid, currentUp, count);
            chunks.Add(chunk);
            i = valid;
        }
        ModInt[] array = Enumerable.Repeat(new ModInt(1), chunks.Count).ToArray();
        for (int _ = 0; _ < k; _++)
        {
            var newArray = new ModInt[chunks.Count];
            ModInt sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i] * chunks[i].Count;
            }
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = sum;
                sum -= array[array.Length - i - 1] * chunks[array.Length - i - 1].Count; 
            }
            array = newArray;
        }
        Console.WriteLine(array[0]);
    }
}

struct Chunk
{
    public int From;
    public int To;
    public int UpTo;
    public int Count;
    public Chunk(int from, int to,int upTo, int count)
    {
        From = from;
        To = to;
        UpTo = upTo;
        Count = count;
    }
    public override string ToString() => $"[{From}, {To}]({Count}), n / i == {UpTo}";
}

struct ModInt
{
    const int MOD = 1000000007;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= MOD ? res - MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => a.Data - b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, int b) => new ModInt() { Data = a.Data * b % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        long div, p = MOD, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + MOD;
            div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + MOD;
            div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
