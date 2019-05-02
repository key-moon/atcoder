// detail: https://atcoder.jp/contests/iroha2019-day2/submissions/5225858
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var river = new Line(new Vector(0, ab[0]), new Vector(xy[0], ab[1]));
        var kamen = new Line(new Vector(s[0], s[1]), new Vector(t[0], t[1]));
        Console.WriteLine(Line.Cross(river, kamen, false) == null ? "No" : "Yes");
    }
}

struct Line
{
    public Vector a;
    public Vector b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Line(Vector a, Vector b) { this.a = a; this.b = b; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector? Cross(Line a, Line b, bool allowOutOfRegion = true)
    {
        double delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        if (delta == 0) return null;
        double ramda = ((b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y)) / delta;
        if (!allowOutOfRegion)
        {
            double mu = ((a.b.x - a.a.x) * (b.b.y - a.a.y) - (a.b.y - a.a.y) * (b.b.x - a.a.x)) / delta;
            if (mu < 0 || 1 < mu || ramda < 0 || 1 < ramda) return null;
        }
        return new Vector(a.a.x + ramda * (a.b.x - a.a.x), a.a.y + ramda * (a.b.y - a.a.y));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"({a}, {b})";
}
struct Vector
{
    public double x;
    public double y;
    public double this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return index == 0 ? x : y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public double Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return x * x + y * y; }
    }
    public double SqrtLength
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Math.Sqrt(Length); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector(double x, double y) { this.x = x; this.y = y; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector rotateVector(double radian) => new Vector(x * Math.Cos(radian) - y * Math.Sin(radian), x * Math.Sin(radian) + y * Math.Cos(radian));
    #region static
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double CrossProduct(Vector a, Vector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double InnerProduct(Vector a, Vector b) => a.x * b.x + a.y * b.y;
    #endregion
    #region operator
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    #endregion
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => this == (Vector)obj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => (x.GetHashCode() * 361870051) ^ (y.GetHashCode() * 1935498511);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"({x}, {y})";
}
