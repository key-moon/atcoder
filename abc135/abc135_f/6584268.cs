// detail: https://atcoder.jp/contests/abc135/submissions/6584268
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
    static bool inf = false;
    static string s;
    static string t;

    //実はループするから目も入らない TLEしたら消す
    static int[] memo;
    static bool[] calling;
    //頭から何文字
    static ModInt[] sHash;
    //頭から何文字
    static ModInt[] tHash;
    static void Main()
    {
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
        {
            powMemo[i] = powMemo[i - 1] * 27;
        }
        s = Console.ReadLine();
        t = Console.ReadLine();
        memo = Enumerable.Repeat(-1, s.Length).ToArray();
        calling = new bool[s.Length];
        sHash = CreateHash(s);
        tHash = CreateHash(t);
        //s.length <= t.lengthの場合、i=2で成立する場合は全て成立 ほんとか いいえ シミュレーションができる うん できるね 
        //†rolling hash†
        var res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            res = Max(res, Solve(i));
            if (inf)
            {
                Console.WriteLine(-1);
                return;
            }
        }
        Console.WriteLine(res);
    }

    static ModInt[] powMemo = new ModInt[500001];
    static ModInt Slice(this ModInt[] hash, int begin, int length)
    {
        return hash[begin + length] - hash[begin] * powMemo[length];
    }

    static ModInt[] CreateHash(string s)
    {
        var hash = new ModInt[s.Length + 1];
        for (int i = 0; i < s.Length; i++)
        {
            hash[i + 1] = hash[i] * 27 + (s[i] - 96);
        }
        return hash;
    }

    //sの何番目からtを取り始めたら何個行けるか
    static int Solve(int begin)
    {
        if (calling[begin])
        {
            inf = true;
            return memo[begin] = 0;
        }
        int loop = 1;
        calling[begin] = true;
        var tPlace = 0;
        var sPlace = begin;
        var remainLength = t.Length;
        while (remainLength != 0)
        {
            var nextLength = Min(remainLength, Min(t.Length - tPlace, s.Length - sPlace));
            if (sHash.Slice(sPlace, nextLength) != tHash.Slice(tPlace, nextLength)) { calling[begin] = false; return memo[begin] = 0; }
            remainLength -= nextLength;
            sPlace += nextLength;
            tPlace += nextLength;
            if (sPlace == s.Length) sPlace = 0;
            if (tPlace == t.Length) tPlace = 0;
        }
        var res = (memo[sPlace] != -1 ? memo[sPlace] : Solve(sPlace)) + 1;
        calling[begin] = false;
        return memo[begin] = res;
    }
}


struct ModInt
{
    const int MOD = 745731223;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, int b) => a.Data + b;
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
