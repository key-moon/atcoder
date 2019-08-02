// detail: https://atcoder.jp/contests/otemae2019/submissions/6648148
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //今n桁目まで見ている
        //どこまで消費したか?
        //225nm
        //1000*1000*225 きびしい

        //3で割ったあまり/5で割り切れるか だけ持っておけばなんとかなる
        ModInt[][] dp = Enumerable.Range(0, nm[1] + 1).Select(_ => new ModInt[3]).ToArray();
        dp[0][0] = 1;
        int[] query = Enumerable.Repeat(0, nm[1]).Select(_ => parseFizzBuzz(Console.ReadLine())).ToArray();
        for (int i = 0; i < nm[0]; i++)
        {
            ModInt[][] newdp = Enumerable.Range(0, nm[1] + 1).Select(_ => new ModInt[3]).ToArray();
            for (int j = 0; j < dp.Length; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int l = (i == 0 ? 1 : 0); l < 10; l++)
                    {
                        var isDividableBy3 = (k + l) % 3 == 0;
                        var isDividableBy5 = l % 5 == 0;
                        var notation = (isDividableBy5 ? 2 : 0) + (isDividableBy3 ? 1 : 0);
                        if (isDividableBy3 || isDividableBy5)
                        {
                            if (j < query.Length && notation == query[j])
                            {
                                newdp[j + 1][(k + l) % 3] += dp[j][k];
                            }
                        }
                        else
                        {
                            newdp[j][(k + l) % 3] += dp[j][k];
                        }
                    }
                }
            }
            dp = newdp;
        }
        Console.WriteLine(dp.Last().Aggregate(new ModInt(0), (x, y) => x + y));
    }

    static int parseFizzBuzz(string s) => s.Length == 8 ? 3 : s[0] == 'B' ? 2 : 1;
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
