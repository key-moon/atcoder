// detail: https://atcoder.jp/contests/agc036/submissions/6953359
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
        var n = NextInt;
        var m = NextInt;
        //えー
        //奇数が何個あるかみたいな話で、
        //奇数がp個、残りのsumがnで 頑張って配置しましょうねみたいな問題
        //仕切りとの並び替え定期

        //いや、玉のmaxがあるやんけ うくか?
        //玉のmaxを超えてる奴をあとから引いてあげましょうねみたいな話
        //maxを超える候補は一つなので、maxの種類ごとにその下の分けるのを全部探索して良さそう いいね
        ModInt res = 0;
        for (int oddCount = (m % 2); oddCount <= n && oddCount <= m * 3; oddCount += 2)
        {
            //奇数の位置*2のブロックの配置

            //奇数の位置 : n! / (odd! * even!)
            var oddPermutation = Factorial(n) / Factorial(oddCount) / Factorial(n - oddCount);

            //2のブロック
            //|と(oo)の並び替え |はn-1個、(oo)は(m*3-oddCount)/2個
            var blockCount = (m * 3 - oddCount) / 2;
            //ブロックの個数がm個みまんだったら駄目
            if (blockCount < m) continue;
            var partationCount = n - 1;
            var blockPermutation = Factorial(blockCount + partationCount) / Factorial(blockCount) / Factorial(partationCount);
            res += oddPermutation * blockPermutation;
        }

        for (int over = m * 2 + 1; over <= m * 3; over++)
        {
            var remain = m * 3 - over;
            //remainブロックをn-1個の区画に入れる
            var partationCount = n - 2;
            var perm = Factorial(remain + partationCount) / Factorial(remain) / Factorial(partationCount);
            //挿入箇所のn通り
            res -= perm * n;
        }
        Console.WriteLine(res);
    }

    static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
    static ModInt Factorial(int x)
    {
        for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
        return factorialMemo[x];
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
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
