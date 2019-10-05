// detail: https://atcoder.jp/contests/agc039/submissions/7874260
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
    static int n;
    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        //n is odd : 10101010101
        //n is even : 1100110011
        string X = Console.ReadLine();
        
        var res = new ModInt(0);

        List<int> factors = new List<int>();
        var sqrt = (int)Ceiling(Sqrt(n)) + 1;
        for (int i = 1; i <= sqrt; i++)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                factors.Add(n / i);
            }
        }

        ModInt[] alreadyCount = new ModInt[n + 1];
        var blockCounts = factors.Distinct().OrderByDescending(x => x).Where(x => x % 2 == 1).ToArray();
        foreach (var blockCount in blockCounts)
        {
            ModInt perm = new ModInt(0);
            var blockLen = n / blockCount;
            var cand = X.Substring(0, blockLen);

            var special = MakeSpecial(cand);
            bool containCand = X.CompareTo(special) >= 0;
            
            int specialCircleFreq = blockLen * 2;
            var parsedCand = Parse(cand);
            var count = (parsedCand + (containCand ? 1 : 0)) - alreadyCount[blockCount];
            perm += count * specialCircleFreq;

            for (int i = 3; i <= blockCount; i++)
            {
                //blockをi個集めてから
                if (blockCount % i != 0) continue;
                //要は今回のやつの個数は 普通に含まれてるので
                alreadyCount[blockCount / i] += count;
            }
            res += perm;
        }
        Console.WriteLine(res);
    }

    static string MakeSpecial(string block)
    {
        var blockCount = n / block.Length;
        var rev = string.Join("", block.Select(x => x == '0' ? '1' : '0'));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < blockCount; i++)
        {
            if (i % 2 == 0) builder.Append(block);
            else builder.Append(rev);
        }
        return builder.ToString();
    }

    static string Decr(string s)
    {
        bool carry = true;
        char[] res = new char[s.Length];
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (carry)
            {
                if (s[i] == '1') carry = false;
                res[i] = s[i] == '0' ? '1' : '0';
            }
            else res[i] = s[i];
        }
        return string.Join("", res);
    }

    static ModInt Parse(string s)
    {
        ModInt curDig = 1;
        ModInt res = 0;
        foreach (var c in s.Reverse())
        {
            if (c == '1') res += curDig;
            curDig *= 2;
        }
        return res;
    }
}

struct ModInt
{
    const int MOD = 998244353;
    const long POSITIVIZER = ((long)MOD) << 31;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= MOD ? res - MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
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
            if (p == 1) return x2 + MOD; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + MOD; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
