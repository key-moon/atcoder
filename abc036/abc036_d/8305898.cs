// detail: https://atcoder.jp/contests/abc036/submissions/8305898
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

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int>[] neighbours = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = ab[0] - 1;
            var b = ab[1] - 1;
            neighbours[a].Add(b);
            neighbours[b].Add(a);
        }
        bool[] arrived = new bool[n];
        ModInt[] numberBlack = new ModInt[n];
        ModInt[] numberWhite = new ModInt[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        arrived[0] = true;
        Action<int, int> func = null;
        func = (node, from) =>
        {
            numberBlack[node] = 1;
            numberWhite[node] = 1;
            foreach (var child in neighbours[node])
            {
                if (child == from) continue;
                func(child, node);
                numberBlack[node] *= numberWhite[child];
                numberWhite[node] *= numberWhite[child] + numberBlack[child];
            }
        };
        func(0, -1);
        Console.WriteLine(numberBlack[0] + numberWhite[0]);
    }
}


struct ModInt
{
    const int MOD = 1000000007;
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
