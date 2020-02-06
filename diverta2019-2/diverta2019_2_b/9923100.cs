// detail: https://atcoder.jp/contests/diverta2019-2/submissions/9923100
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        var balls = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new Vector(x[0], x[1])).ToArray();
        var res = n - balls.SelectMany(x => balls.Select(y => x - y)).GroupBy(x => x).OrderByDescending(x => x.Count()).Skip(1).First().Count();
        Console.WriteLine(res);
    }
}


struct Vector
{
    public int x;
    public int y;
    public int this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index == 0) return x; else return y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public int Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector(int x, int y) { this.x = x; this.y = y; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector RotateVector(double radian) => new Vector((int)(x * Math.Cos(radian) - y * Math.Sin(radian)), (int)(x * Math.Sin(radian) + y * Math.Cos(radian)));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public int CrossProduct(Vector a, Vector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public int InnerProduct(Vector a, Vector b) => a.x * b.x + a.y * b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
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
