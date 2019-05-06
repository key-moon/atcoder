// detail: https://atcoder.jp/contests/abc009/submissions/5288537
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
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var km = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = km[0];
        var m = km[1];
        var iv = new Matrix(k, 1);
        for (int i = k - 1; i >= 0; i--) iv[i, 0] = Read();
        var stateTransitionMatrix = new Matrix(k, k);
        for (int i = 0; i < k - 1; i++) stateTransitionMatrix[i + 1, i] = uint.MaxValue;
        for (int i = 0; i < k; i++) stateTransitionMatrix[0, i] = Read();
        Console.WriteLine((Power(stateTransitionMatrix, m - 1) * iv)[k - 1, 0]);
    }

    static Matrix Power(Matrix n, long m)
    {
        Matrix pow = n;
        Matrix res = Matrix.GetScalarMatrix(n.Height, uint.MaxValue);
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static uint Read()
    {
        uint res = 0;
        uint next = (uint)In.Read();
        while (48 > next || next > 57) next = (uint)In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = (uint)In.Read();
        }
        return res;
    }
}


class Matrix
{
    public readonly int Height;
    public readonly int Width;
    uint[,] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix(int height, int width)
    {
        data = new uint[height, width];
        Height = height;
        Width = width;
    }
    public uint this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i, j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { data[i, j] = value; }
    }
    public static Matrix GetScalarMatrix(int size, uint scalar)
    {
        var res = new Matrix(size, size);
        for (int i = 0; i < size; i++) res[i, i] = scalar;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Mul(Matrix a, Matrix b)
    {
        Debug.Assert(a.Width == b.Height);
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++) res[i, j] ^= a[i, k] & b[k, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator *(Matrix a, Matrix b) => Mul(a, b);
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < Height; i++)
        {
            builder.Append(i != 0 ? " [" : "[[");
            for (int j = 0; j < Width; j++)
            {
                builder.Append(data[i, j].ToString().PadLeft(11));
                if(j != Width - 1) builder.Append(",");
            }
            builder.Append(i != Height - 1 ? "],
" : "]]");
        }
        return builder.ToString();
    }
}
