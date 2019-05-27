// detail: https://atcoder.jp/contests/cpsco2019-s1/submissions/5668326
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
        var n = long.Parse(Console.ReadLine());
        var morning = new ModMatrix(3, 3);
        var other = new ModMatrix(3, 3);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == j) continue;
                if (i != 2) morning[i, j] = 1;
                other[i, j] = 1;
            }
        }
        var iv = new ModMatrix(3, 1);
        iv[0, 0] = 1;
        iv[1, 0] = 1;
        var last = Power(other * other * morning, n - 1) * (other * other * iv);
        Console.WriteLine((last[0, 0] + last[1, 0] + last[2, 0]) % 1000000007);
    }

    static ModMatrix Power(ModMatrix n, long m)
    {
        ModMatrix pow = n;
        ModMatrix res = new ModMatrix(n.Height, n.Width);
        for (int i = 0; i < n.Height; i++) res[i, i] = 1;
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
    const int MOD = 1000000007;
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
