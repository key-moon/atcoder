// detail: https://atcoder.jp/contests/kupc2012pr/submissions/5286280
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
        DateTime start = DateTime.Now;
        int n = int.Parse(Console.ReadLine());
        Matrix a = new Matrix(n, n);
        Matrix b = new Matrix(n, n);
        Matrix c = new Matrix(n, n);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                a[i, j] = Read();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                b[i, j] = Read();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                c[i, j] = Read();
        for (int i = 0; i < 20; i++)
        {
            var randomVector = GetRandomVector(n);
            if (a * (b * randomVector) != c * randomVector)
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine("YES");
    }
    static Random RNG = new Random();
    static Matrix GetRandomVector(int n)
    {
        Matrix res = new Matrix(n, 1);
        for (int i = 0; i < n; i++) res[i, 0] = RNG.Next() & 1;
        return res;
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        int sign = 1;
        while (45 > next || next > 57) next = In.Read();
        while (45 <= next && next < 48)
        {
            sign = -1;
            next = In.Read();
        }
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res * sign;
    }
}

class Matrix : IEquatable<Matrix>
{
    public readonly int Height;
    public readonly int Width;
    long[,] data;
    public Matrix(int height, int width)
    {
        data = new long[height, width];
        Height = height;
        Width = width;
    }
    public long this[int i, int j]
    {
        get { return data[i, j]; }
        set { data[i, j] = value; }
    }
    public static Matrix Multiple(Matrix a, Matrix b)
    {
        Debug.Assert(a.Width == b.Height);
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++)
            for (int j = 0; j < b.Width; j++)
                for (int k = 0; k < a.Width; k++)
                    res[i, j] += a[i, k] * b[k, j];
        return res;
    }

    public bool Equals(Matrix other)
    {
        if (this.Width != other.Width || this.Height != other.Height) return false;
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                if (this[i, j] != other[i, j]) return false;
        return true;
    }

    public static Matrix operator *(Matrix a, Matrix b) => Multiple(a, b);
    public static bool operator ==(Matrix a, Matrix b) => a.Equals(b);
    public static bool operator !=(Matrix a, Matrix b) => !a.Equals(b);
}

[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    [FieldOffset(0)]
    private sbyte __sbyte;
    [FieldOffset(0)]
    private char __char;
    [FieldOffset(0)]
    private short __short;
    [FieldOffset(0)]
    private ushort __ushort;
    [FieldOffset(0)]
    private int __int;
    [FieldOffset(0)]
    private uint __uint;
    [FieldOffset(0)]
    private long __long;
    [FieldOffset(0)]
    private ulong __ulong;

    public byte Byte { get { Update(); return __byte; } }
    public sbyte SByte { get { Update(); return __sbyte; } }
    public char Char { get { Update(); return __char; } }
    public short Short { get { Update(); return __short; } }
    public ushort UShort { get { Update(); return __ushort; } }
    public int Int { get { Update(); return __int; } }
    public uint UInt { get { Update(); return __uint; } }
    public long Long { get { Update(); return __long; } }
    public ulong ULong { get { Update(); return __ulong; } }
    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public int Next() => Int & 2147483647;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
