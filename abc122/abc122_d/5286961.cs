// detail: https://atcoder.jp/contests/abc122/submissions/5286961
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
        int n = int.Parse(Console.ReadLine());
        //matrix[i,j]:vector[i]の要素がaであればi行目のj要素にaで乗算が行われる(DPの遷移と同じ)
        ModMatrix matrix = new ModMatrix(4 * 4 * 4, 4 * 4 * 4);
        //t : 0
        //a : 1
        //g : 2
        //c : 3

        for (int i = 0; i < matrix.Height; i++)
        {
            int val = i;
            
            //t s f
            int firstLiteral = val % 4;
            val /= 4;
            int secondLiteral = val % 4;
            val /= 4;
            int thirdLiteral = val % 4;

            
            //ダメなのはagc,gac,acg,a_gc,ag_c

            //tが追加された時
            matrix[i, (secondLiteral * 4 + firstLiteral) * 4 + 0] += 1;

            //aが追加された時
            matrix[i, (secondLiteral * 4 + firstLiteral) * 4 + 1] += 1;

            //gが追加された時:acgが起こりうる
            if (!(secondLiteral == 1 && firstLiteral == 3/*acg*/)) matrix[i, (secondLiteral * 4 + firstLiteral) * 4 + 2] += 1;

            //cが追加された時 : agc,gac,a_gc,ag_cが起こりうる
            if (!(secondLiteral == 1 && firstLiteral == 2/*agc*/) &&
                !(secondLiteral == 2 && firstLiteral == 1/*gac*/) &&
                !(thirdLiteral == 1 && firstLiteral == 2/*a_gc*/) &&
                !(thirdLiteral == 1 && secondLiteral == 2/*ag_c*/)) matrix[i, (secondLiteral * 4 + firstLiteral) * 4 + 3] += 1;
        }

        ModMatrix res = new ModMatrix(1, 4 * 4 * 4);
        res[0, 0] = 1;
        while (n > 0)
        {
            if ((n & 1) == 1) res *= matrix;
            matrix *= matrix;
            n >>= 1;
        }

        long resSum = 0;
        for (int i = 0; i < res.Width; i++) resSum += res[0, i];
        Console.WriteLine(resSum % 1000000007);
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
