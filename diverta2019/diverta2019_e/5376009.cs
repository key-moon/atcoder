// detail: https://atcoder.jp/contests/diverta2019/submissions/5376009
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //仕切りを最初は全ての0の後に入れておく 仕切りを取り払う(=一つ前のセクションとマージする)か、仕切りを入れる
        //とりあえず、全ての0セクション内に仕切りを入れる場合を考える
        //全てのセクションについてある数を含んでいる場合は
        //今そこで仕切れるよ っていう情報
        //dp[目標とする美しさ][現在の目標(0:0 or 1:目標)]
        //0が来た時は遅延評価で良い?最後に来た0の時間をメモしておいて、どの0を採用するかで掛ける
        //[目標までのXOR]仕切りを入れる/入れない
        int accumXor = 0;
        int zeroCount = 0;
        //このまま最後まで伸びるとした場合のそれ
        ModInt[] eachRes = new ModInt[1 << 20];
        ModInt[] dp = Enumerable.Repeat(new ModInt(1), 1 << 20).ToArray();
        int[] lastZero = new int[1 << 20];
        int[] sameRegionCount = new int[1 << 20];
        //一個前からの経過 + 一個前をabortして今そこで区切る
        for (int i = 0; i < a.Length; i++)
        {
            accumXor ^= a[i];
            if (accumXor == 0)
            {
                zeroCount++;
                continue;
            }
            //前回からの区切りの数
            var possibleSeparateCount = zeroCount - lastZero[accumXor];
            lastZero[accumXor] = zeroCount;

            dp[accumXor] += eachRes[accumXor] * possibleSeparateCount;
            eachRes[accumXor] += dp[accumXor];
        }

        if (accumXor == 0)
        {
            ModInt res = 0;
            //0セクションのみを加算
            var zeroSectionOnly = Power(2, zeroCount - 1);
            res += zeroSectionOnly;
            for (int i = 1; i < dp.Length; i++) res += eachRes[i];
            Console.WriteLine(res);
        }
        else
        {
            Console.WriteLine(dp[accumXor]);
        }
    }

    static ModInt Power(ModInt n, long m)
    {
        ModInt pow = n;
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
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
