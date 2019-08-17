// detail: https://atcoder.jp/contests/agc037/submissions/6963128
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] s = Console.ReadLine().Select(x => (x == 'R' ? 0 : x == 'G' ? 1 : 2)).ToArray();

        //最後の文字が同じで、範囲がかぶってる奴の最後の文字のswap
        //最後の文字

        ModInt res = 1;

        int i = 0;
        while (i < s.Length)
        {
            int nextRole = 0;
            int[] roleChar = new int[] { -1, -1, -1 };
            int[] roleOf = new int[] { -1, -1, -1 };
            ModInt[] firstCounts = new ModInt[] { 0, 0 };
            ModInt secondCount = 0;
            //roleが[0,1,2] or [1,0,2]のみ成立
            do
            {
                if (roleOf[s[i]] == -1)
                {
                    while (roleChar[nextRole] != -1) nextRole++;
                    roleChar[roleOf[s[i]] = nextRole++] = s[i];
                }
                var role = roleOf[s[i]];
                switch (role)
                {
                    case 2:
                        res *= secondCount;
                        secondCount--;
                        break;
                    default:
                        if (firstCounts[role ^ 1] != 0)
                        {
                            res *= firstCounts[role ^ 1];
                            firstCounts[role ^ 1]--;
                            secondCount++;
                        }
                        else
                        {
                            firstCounts[role]++;
                        }
                        break;
                }
                if (role == 2 && secondCount == 0)
                {
                    //role空のほう、2を殺す
                    var killRole = firstCounts[0] == 0 ? 0 : 1;
                    roleOf[roleChar[killRole]] = -1;
                    roleChar[killRole] = -1;
                    roleOf[roleChar[2]] = -1;
                    roleChar[2] = -1;
                    nextRole = 0;
                }
                i++;
            } while (firstCounts.Any(x => x != 0) || secondCount != 0);
        }

        res *= Factorial(n);
        Console.WriteLine(res);
    }


    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
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
