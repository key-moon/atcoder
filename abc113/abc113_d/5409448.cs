// detail: https://atcoder.jp/contests/abc113/submissions/5409448
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        var k = hwk[2];
        if (w == 1)
        {
            Console.WriteLine(1);
            return;
        }
        ModInt[] counts = new ModInt[w];
        counts[0] = 1;
        for (int row = 0; row < h; row++)
        {
            ModInt[] newCounts = new ModInt[w];
            for (int i = 0; i < 1 << (w - 1); i++)
            {
                if (Enumerable.Range(0, w - 2).Any(x => ((i >> x) & (i >> (x + 1)) & 1) == 1)) continue;
                for (int j = 0; j < w; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        newCounts[j] += counts[j + 1];
                        newCounts[j + 1] += counts[j];
                        j++;
                    }
                    else
                    {
                        newCounts[j] += counts[j];
                    }
                }
            }
            counts = newCounts;
        }
        Console.WriteLine(counts[k - 1]);
    }
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
    public static ModInt operator +(ModInt a, ModInt b)
    {
        long res = a.Data + b.Data;
        return new ModInt() { Data = res >= MOD ? res - MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b)
    {
        long res = a.Data - b.Data;
        return new ModInt() { Data = res < 0 ? res + MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => a.Data - b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => a.Data * GetInverse(b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        long div;
        long p = MOD;
        long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2;
            div = a / p;
            x1 -= x2 * div;
            y1 -= y2 * div;
            a %= p;
            if (a == 1) return x1;
            div = p / a;
            x2 -= x1 * div;
            y2 -= y1 * div;
            p %= a;
        }
    }
}
