// detail: https://atcoder.jp/contests/exawizards2019/submissions/4776274
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

        int[] s = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();

        long[] dp = new long[X + 1];
        dp[X] = 1;
        int remain = s.Length - 1;
        foreach (var mod in s)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                var tem = dp[i];
                dp[i % mod] += tem;
                dp[i % mod] %= 1000000007;
                dp[i] += tem * (remain - 1);
                dp[i] %= 1000000007;
            }
            remain--;
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
    public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Eval() + b.Eval());
    public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Eval() - b.Eval());
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt(a.Eval() * b.Eval());
    public static ModInt operator /(ModInt a, ModInt b) => a * Power(b.Eval(), MOD - 2);

    public override string ToString() => Data.ToString();

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
