// detail: https://atcoder.jp/contests/nikkei2019-2-final/submissions/8962238
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
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var s = Console.ReadLine();
        var n = s.Length;
        RollingHash hash = new RollingHash(s);
        long res = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            //|-n-|-i-|-k-|-k-|-e-|-i-|
            var len = s.Length - i;
            var s6 = hash.Slice(i, n - i);
            for (int j = 1; j < n - len * 2; j++)
            {
                if (s6 != hash.Slice(j, len)) continue;
                var middleLen = (n - j) - len * 2;
                var startInd = j + len;
                for (int k = 1; k <= (middleLen - 1) / 2; k++)
                {
                    var first = hash.Slice(startInd, k);
                    var second = hash.Slice(startInd + k, k);
                    if (first == second) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[500 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(129, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }

    ulong[] hash;

    public RollingHash(string s)
    {
        hash = new ulong[s.Length + 1];
        for (int i = 0; i < s.Length; i++)
            hash[i + 1] = CalcMod(Mul(hash[i], Base) + s[i]);
    }

    public ulong Slice(int begin, int length)
    {
        return CalcMod(hash[begin + length] + POSITIVIZER - Mul(hash[begin], powMemo[length]));
    }

    private static ulong Mul(ulong l, ulong r)
    {
        var lu = l >> 31;
        var ld = l & MASK31;
        var ru = r >> 31;
        var rd = r & MASK31;
        var middleBit = ld * ru + lu * rd;
        return ((lu * ru) << 1) + ld * rd + ((middleBit & MASK30) << 31) + (middleBit >> 30);
    }

    private static ulong Mul(ulong l, uint r)
    {
        var lu = l >> 31;
        var rd = r & MASK31;
        var middleBit = lu * rd;
        return (l & MASK31) * rd + ((middleBit & MASK30) << 31) + (middleBit >> 30);
    }

    private static ulong CalcMod(ulong val)
    {
        val = (val & MOD) + (val >> 61);
        if (val > MOD) val -= MOD;
        return val;
    }
}
