// detail: https://atcoder.jp/contests/exawizards2019/submissions/5095172
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
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long X = nx[1];
        //ちゅーごくじょーよてーり
        //オーダーによってSの終端が決定する
        //まず影響するのは降順のみなことは自明に分かって、
        //で、「次」を選ぶことができる順番は
        //「確率」「期待値」
        //aを取り除いた場合、その後に適用できるのはそれ以前全て。

        List<int> s = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
        ModInt[] dp = new ModInt[X + 1];
        dp[X] = 1;
        int remain = s.Count - 1;
        foreach (var mod in s)
        {
            ModInt[] newDP = new ModInt[X + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                newDP[i % mod] += dp[i];
                newDP[i] += dp[i] * remain;
            }
            remain--;
            dp = newDP;
        }
        ModInt res = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            res += dp[i] * i;
        }
        Console.WriteLine(res);
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
    public static ModInt operator +(ModInt a, ModInt b)
    {
        long res = a.Data + b.Data;
        return new ModInt() { Data = res >= MOD ? res - MOD : res };
    }
    public static ModInt operator -(ModInt a, ModInt b)
    {
        long res = a.Data - b.Data;
        return new ModInt() { Data = res < 0 ? res + MOD : res };
    }
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt(a.Data * b.Data);
    public static ModInt operator /(ModInt a, ModInt b) => a * Power(b, MOD - 2);

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
