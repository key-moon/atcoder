// detail: https://atcoder.jp/contests/abc066/submissions/4820723
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();

        var doubleElem = a.GroupBy(x => x).First(x => x.Count() == 2).Key;
        int firstIndexOfDouble = a.IndexOf(doubleElem);
        int lastIndexOfDouble = a.LastIndexOf(doubleElem);

        ModInt all = 1;
        ModInt duplicate = 1;
        for (int i = 1; i <= n + 1; i++)
        {
            all = (all * (n + 2 - i) / i);
            Console.WriteLine(all - duplicate);

            duplicate = duplicate * (firstIndexOfDouble + (n - lastIndexOfDouble) - i + 1) / i;
            
        }
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

    static ModInt Power(ModInt n, long m)
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
