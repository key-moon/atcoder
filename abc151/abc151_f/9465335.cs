// detail: https://atcoder.jp/contests/abc151/submissions/9465335
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;
using static Reader;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.InteropServices;

public static class P
{
    public static double[] Sin = new double[1024];
    public static double[] Cos = new double[1024];
    public static void Main()
    {
        for (int i = 0; i < 1024; i++)
        {
            Sin[i] = Sin(2 * PI / 1024 * i);
            Cos[i] = Cos(2 * PI / 1024 * i);
        }
        var n = NextInt;
        Vector[] points = Enumerable.Repeat(0, n).Select(_ => new Vector(NextInt, NextInt)).ToArray();
        double res = double.MaxValue;
        for (ulong i = 1; i <= 10; i++)
        {
            res = Min(res, Solve(points, i));
        }

        Console.WriteLine(res);
    }

    static double Solve(Vector[] points, ulong seed)
    {
        Random RNG = new Random(seed);
        var current = new Vector(495 + RNG.Double * 10, 495 + RNG.Double * 10);
        var gran = 300.0;

        var curMin = points.Max(x => (x - current).Length);
        for (int _ = 0; _ < 150; _++)
        {
            var curMinPoint = current;
            for (int i = 0; i < 1024; i += 2)
            {
                var next = current + new Vector(gran, 0).RotateVector(i);

                var rad = points.Max(x => (x - next).Length);
                if (rad < curMin)
                {
                    curMin = rad;
                    curMinPoint = next;
                }
            }
            current = curMinPoint;
            gran *= 0.85;
        }

        return Sqrt(curMin);
    }

    static Vector RotateVector(this Vector v, int ind) => new Vector((double)(v.x * Cos[ind] - v.y * Sin[ind]), (double)(v.x * Sin[ind] + v.y * Cos[ind]));
}

struct Vector
{
    public double x;
    public double y;
    public double this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index == 0) return x; else return y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public double Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector(double x, double y) { this.x = x; this.y = y; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector RotateVector(double radian) => new Vector((double)(x * Math.Cos(radian) - y * Math.Sin(radian)), (double)(x * Math.Sin(radian) + y * Math.Cos(radian)));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double CrossProduct(Vector a, Vector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double InnerProduct(Vector a, Vector b) => a.x * b.x + a.y * b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
    public static Vector operator *(Vector a, double b) => new Vector(a.x * b, a.y * b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => this == (Vector)obj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => x.GetHashCode() * 1000000007 + y.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"({x},{y})";
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }

    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
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
