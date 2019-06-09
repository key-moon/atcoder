// detail: https://atcoder.jp/contests/abc129/submissions/5860419
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var l = Read();
        var a = Read();
        var b = Read();
        var m = (int)Read();
        ModMatrix.MOD = m;
        ModInt.MOD = m;

        long lastRem = 0;
        long n = 0;
        for (int digits = GetDigits(a); digits < 40; digits++)
        {
            ModMatrix matrix = new ModMatrix(3, 3);
            matrix[0, 0] = Power(10, digits);
            matrix[0, 1] = b;
            matrix[0, 2] = a;
            matrix[1, 1] = 1;
            matrix[1, 2] = 1;
            matrix[2, 2] = 1;
            ModMatrix iv = new ModMatrix(3, 1);
            iv[0, 0] = lastRem;
            iv[1, 0] = n;
            iv[2, 0] = 1;

            BigInteger valid = n - 1;
            BigInteger invalid = new BigInteger(long.MaxValue) * 1000000;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (GetDigits(a + b * mid) == digits) valid = mid;
                else invalid = mid;
            }

            if (l - 1 <= valid) valid = l - 1;

            var count = (long)valid - n + 1;
            var resMatrix = Power(matrix, count) * iv;
            lastRem = resMatrix[0, 0];
            n = (long)valid + 1;
            if (valid == l - 1) break;
        }
        Console.WriteLine(lastRem);
    }

    static int GetDigits(BigInteger x) => x.ToString().Length;

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Read()
    {
        long res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }


    static ModInt Power(ModInt n, long m)
    {
        ModInt pow = n;
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }


    static ModMatrix Power(ModMatrix n, long m)
    {
        ModMatrix pow = n;
        ModMatrix res = ModMatrix.GetScalarMatrix(n.Height, 1);
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }
}



class ModMatrix : IEquatable<ModMatrix>
{
    public static int MOD = 1000000007;
    public readonly int Height;
    public readonly int Width;
    long[,] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModMatrix(int height, int width)
    {
        data = new long[height, width];
        Height = height;
        Width = width;
    }
    public long this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i, j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if ((data[i, j] = value % MOD) < 0) data[i, j] += MOD; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ModMatrix other)
    {
        if (this.Width != other.Width || this.Height != other.Height) return false;
        for (int i = 0; i < Height; i++) for (int j = 0; j < Width; j++) if (this[i, j] != other[i, j]) return false;
        return true;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Add(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Width && a.Height == b.Height);
        var res = new ModMatrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) if (MOD <= (res.data[i, j] = a[i, j] + b[i, j])) res.data[i, j] -= MOD;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Sub(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Width && a.Height == b.Height);
        var res = new ModMatrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) if ((res.data[i, j] = a[i, j] - b[i, j]) < 0) res.data[i, j] += MOD;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Mul(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Height);
        var res = new ModMatrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) { for (int k = 0; k < a.Width; k++) res.data[i, j] += a[i, k] * b[k, j] % MOD; res.data[i, j] %= MOD; }
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix GetScalarMatrix(int size, uint scalar)
    {
        var res = new ModMatrix(size, size);
        for (int i = 0; i < size; i++) res[i, i] = scalar;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator +(ModMatrix a, ModMatrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator -(ModMatrix a, ModMatrix b) => Sub(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator *(ModMatrix a, ModMatrix b) => Mul(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ModMatrix a, ModMatrix b) => a.Equals(b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ModMatrix a, ModMatrix b) => !a.Equals(b);
}


struct ModInt
{
    public static int MOD = 1000000007;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b)
    {
        long res = a.Data + b.Data;
        return new ModInt() { Data = res >= MOD ? res - MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => a.Data + b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b)
    {
        long res = a.Data - b.Data;
        return new ModInt() { Data = res < 0 ? res + MOD : res };
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => a.Data - b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();
}
