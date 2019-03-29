// detail: https://atcoder.jp/contests/abc042/submissions/4750755
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var hwab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hwab[0];
        int w = hwab[1];
        int a = hwab[2];
        int b = hwab[3];
        ModInt res = 0;;
        for (int i = 0; i < h - a; i++) res += (Factorial(i + b - 1) / (Factorial(i) * Factorial(b - 1))) * (Factorial((w - b - 1) + (h - i - 1)) / (Factorial(w - b - 1) * Factorial(h - i - 1)));
        Console.WriteLine((long)res);
    }

    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
    }
}

struct ModInt
{
    const int MOD = 1000000007;
    long Data;
    public ModInt(long data) { Data = data; Eval(); }

    private long Eval() => (Data %= MOD) < 0 ? Data += MOD : Data;
    public static implicit operator long(ModInt modInt) => modInt.Eval();
    public static implicit operator ModInt(long val) => new ModInt(val);
    public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Eval() + b.Eval());
    public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Eval() - b.Eval());
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt(a.Eval() * b.Eval());
    public static ModInt operator /(ModInt a, ModInt b) => a * Power(b.Eval(), MOD - 2);

    static ModInt Power(ModInt n, ModInt m)
    {
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= n;
            n *= n;
            m >>= 1;
        }
        return res;
    }
}
