// detail: https://atcoder.jp/contests/abc132/submissions/6174320
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
        var blue = (k);
        var red = (n - k);
        //青をiグループ、赤をi-1,i,i+1グループ
        StringBuilder builder = new StringBuilder();
        for (int i = 1; i <= k; i++)
        {
            //仕切りを入れる
            var bluePartation = Calc(blue, i);
            var m1 = (i == 1 ? 0 : Calc(red, i - 1));
            var z = Calc(red, i) * 2;
            var p1 = Calc(red, i + 1);
            var redPartation = (i == 1 ? (red == 0 ? 1 : 0) : Calc(red, i - 1)) + (Calc(red, i) * 2) + Calc(red, i + 1);
            builder.AppendLine((bluePartation * redPartation).ToString());
        }
        Console.Write(builder.ToString());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static ModInt Calc(int count, int partation)
    {
        if (count < partation) return 0;
        if (partation == 1) return 1;
        return Factorial(count - 1) * FactorialInv(partation - 1) * FactorialInv(count - partation);
    }

    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
    }

    static List<ModInt> factorialInvMemo = new List<ModInt>() { 1 };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static ModInt FactorialInv(int x)
    {
        for (int i = factorialInvMemo.Count; i <= x; i++) factorialInvMemo.Add(factorialInvMemo.Last() / i);
        return factorialInvMemo[x];
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
    public static long GetInverse(long a)
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
