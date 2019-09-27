// detail: https://atcoder.jp/contests/abc141/submissions/7721074
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        int curMaxLength = 0;
        var hash = new RollingHash(s);
        for (int i = 0; i < s.Length; i++)
            for (int j = i; j < s.Length; j++)
                while (curMaxLength < j - i && j + curMaxLength < n && hash.Slice(i, curMaxLength + 1) == hash.Slice(j, curMaxLength + 1)) curMaxLength++;
        Console.WriteLine(curMaxLength);
    }
}

class RollingHash
{
    const ulong MASK30 = (1UL << 30) - 1;
    const ulong MASK31 = (1UL << 31) - 1;
    const ulong MOD = (1UL << 61) - 1;
    const ulong POSITIVIZER = MOD * ((1UL << 3) - 1);
    static uint Base;
    static ulong[] powMemo = new ulong[5000 + 1];
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
        var ld = l & MASK31;
        var rd = r & MASK31;
        var middleBit = lu * rd;
        return  ld * rd + ((middleBit & MASK30) << 31) + (middleBit >> 30);
    }

    private static ulong CalcMod(ulong val)
    {
        return val % MOD;
    }
}
