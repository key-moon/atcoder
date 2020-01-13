// detail: https://atcoder.jp/contests/abc150/submissions/9492642
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(uint.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(uint.Parse).ToArray();
        b = b.Concat(b).ToArray();
        var aDiffXor = a.Skip(n - 1).Concat(a).Zip(a, (x, y) => x ^ y).ToArray();
        var bDiffXor = b.Skip(n - 1).Concat(b).Zip(b, (x, y) => x ^ y).ToArray();
        RollingHash aHash = new RollingHash(aDiffXor);
        RollingHash bHash = new RollingHash(bDiffXor);
        for (int i = n; i >= 1; i--)
        {
            var aHashVal = aHash.Slice(0, n);
            var bHashVal = bHash.Slice(i, n);
            if (aHashVal != bHashVal) continue;
            Console.WriteLine($"{n - i} {a[0] ^ b[i]}");
        }
    }
}


class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[500000 + 1];
    static RollingHash()
    {
        Base = (uint)new Random().Next(int.MaxValue / 2, int.MaxValue);
        powMemo[0] = 1;
        for (int i = 1; i < powMemo.Length; i++)
            powMemo[i] = CalcMod(Mul(powMemo[i - 1], Base));
    }

    ulong[] hash;

    public RollingHash(uint[] s)
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
        if (val >= MOD) val -= MOD;
        return val;
    }
}
