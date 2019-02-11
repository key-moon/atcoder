// detail: https://atcoder.jp/contests/rco-contest-2019-qual/submissions/4234959
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    public static Random random = new Random(11192916);
    public static int n;
    public static Point[] points;
    public static double[][] dist;
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        points = Enumerable.Repeat(0, n).Select(_ => new Point(Console.ReadLine().Split().Select(int.Parse).ToArray())).ToArray();
        DateTime start = DateTime.Now;
        InitDist();

        int[] maxA = Enumerable.Range(0, n).ToArray();
        double maxScore = -10000;
        for (int _ = 0; _ < 10; _++)
        {
            var cand = Enumerable.Range(0, n).ToArray();
            for (int i = n - 1; i >= 1; i--)
            {
                var j = Abs(random.Int % (i + 1));
                var tmp = cand[i];
                cand[i] = cand[j];
                cand[j] = tmp;
            }
            var score = CalcScore(cand);
            if (maxScore < score)
            {
                maxScore = score;
                maxA = cand;
            }
        }
        //if (maxA.Distinct().Count() != n) throw new Exception();
        //Console.WriteLine($"{(DateTime.Now - start).TotalMilliseconds},{maxScore}");

        int[] lastA = new int[n];
        maxA.CopyTo(lastA, 0);
        double lastScore = maxScore;
        //int iter = 0;
        while (true)
        {
            double duration = (DateTime.Now - start).TotalMilliseconds / 1960;
            if (duration > 1) break;
            //iter++;
            int x = Abs(random.Int % 200);
            int y = Abs(random.Int % 200);
            #region swap
            var tmp = lastA[y];
            lastA[y] = lastA[x];
            lastA[x] = tmp;
            #endregion
            var score = CalcScore(lastA);
            double startTemp = 60;
            double endTemp = 0.16;
            double temp = startTemp + (endTemp - startTemp) * duration;
            //Console.WriteLine($"score : {score},{(score - lastScore > 0 ? "+" : "")}{score - lastScore}");
            if (Exp((score - lastScore) / temp) < (double)random.ULong / ulong.MaxValue)
            {
                #region swap
                tmp = lastA[y];
                lastA[y] = lastA[x];
                lastA[x] = tmp;
                #endregion
            }
            else
            {
                lastScore = score;
                if (maxScore < score)
                {
                    maxScore = score;
                    lastA.CopyTo(maxA, 0);
                }
            }
        }
        //Console.WriteLine(iter);
        //Console.WriteLine(maxScore);
        Console.WriteLine(string.Join("
", maxA));
    }

    static void InitDist()
    {
        dist = new double[n][];
        for (int i = 0; i < dist.Length; i++)
        {
            dist[i] = new double[n];
            for (int j = 0; j < dist[i].Length; j++)
            {
                dist[i][j] = (points[i] - points[j]).Length;
            }
        }
        /*
        dist[n] = new double[n + 1];
        for (int i = 0; i < points.Length + 1; i++)
        {
            dist[n][i] = dist[0][i];
            dist[i][n] = dist[i][0];
        }
        dist[points.Length][points.Length] = dist[0][0];*/
    }
    static double CalcScore(int[] a)
    {
        double sum = 0;
        double[] res = new double[a.Length];
        sum += dist[a[0]][a[a.Length - 1]];
        res[0] = dist[a[0]][a[a.Length - 1]];
        for (int i = 1; i < a.Length; i++)
        {
            sum += dist[a[i]][a[i - 1]];
            res[i] = dist[a[i]][a[i - 1]];
        }
        var ave = sum / res.Length;
        double score = 2000000;
        for (int i = 0; i < res.Length; i++) score -= (res[i] - ave) * (res[i] - ave);
        return score / 200;
    }
}


struct Point
{
    public int x;
    public int y;
    public int this[int index]
    {
        get
        {
            if (index == 0) return x;
            else return y;
        }
        set
        {
            if (index == 0) x = value;
            else y = value;
        }
    }
    /// <summary>長さ</summary>
    public double Length => Sqrt(ManhattanLength);
    public int ManhattanLength => x * x + y * y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Point(int[] a)
    {
        this.x = a[0];
        this.y = a[1];
    }

    #region static

    /// <summary>外積</summary>
    static public double CrossProduct(Point a, Point b)
    {
        return a.x * b.y - a.y * b.x;
    }
    /// <summary>内積</summary>
    static public double InnerProduct(Point a, Point b)
    {
        return a.x * b.x + a.y * b.y;
    }
    #endregion

    #region operator
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.x + b.x, a.y + b.y);
    }
    public static Point operator -(Point a, Point b)
    {
        return new Point(a.x - b.x, a.y - b.y);
    }

    public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Point a, Point b) => a.x != b.x || a.y != b.y;
    #endregion

    public override bool Equals(object obj) => this == (Point)obj;
    public override int GetHashCode() => (x.GetHashCode() * 11192916 + y.GetHashCode());
}

#region random
[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    public byte Byte
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __byte;
        }
    }
    [FieldOffset(0)]
    private sbyte __sbyte;
    public sbyte SByte
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __sbyte;
        }
    }
    [FieldOffset(0)]
    private char __char;
    public char Char
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __char;
        }
    }
    [FieldOffset(0)]
    private short __short;
    public short Short
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __short;
        }
    }
    [FieldOffset(0)]
    private ushort __ushort;
    public ushort UShort
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __ushort;
        }
    }
    [FieldOffset(0)]
    private int __int;
    public int Int
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __int;
        }
    }
    [FieldOffset(0)]
    private uint __uint;
    public uint UInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __uint;
        }
    }
    [FieldOffset(0)]
    private long __long;
    public long Long
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __long;
        }
    }
    [FieldOffset(0)]
    private ulong __ulong;
    public ulong ULong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Next();
            return __ulong;
        }
    }
    [FieldOffset(0)]
    private ulong _xorshift;

    public Random()
    {
        SetSeed((ulong)DateTime.Now.Ticks);
    }
    public Random(ulong seed)
    {
        SetSeed(seed);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
#endregion

#region geometry
struct Line
{
    public Vector a;
    public Vector b;
    public Line(Vector a, Vector b)
    {
        this.a = a;
        this.b = b;
    }

    /// <summary>二直線が交わる点</summary>
    public static Vector Cross(Line a, Line b)
    {
        double delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        if (delta == 0) throw new Exception();
        double ramda = ((b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y)) / delta;
        double mu = ((a.b.x - a.a.x) * (b.b.y - a.a.y) - (a.b.y - a.a.y) * (b.b.x - a.a.x)) / delta;

        return new Vector(a.a.x + ramda * (a.b.x - a.a.x), a.a.y + ramda * (a.b.y - a.a.y));
    }

    public override string ToString() => $"{a} {b}";
}

struct Vector
{
    public double x;
    public double y;
    public double this[int index]
    {
        get
        {
            if (index == 0) return x;
            else return y;
        }
        set
        {
            if (index == 0) x = value;
            else y = value;
        }
    }
    public double Length => Sqrt(ManhattanLength);
    public double ManhattanLength => x * x + y * y;
    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>回転</summary>
    public Vector rotateVector(double radian)
    {
        return new Vector(x * Cos(radian) - y * Sin(radian), x * Sin(radian) + y * Cos(radian));
    }
    /// <summary>長さ</summary>
    #region static

    /// <summary>外積</summary>
    static public double CrossProduct(Vector a, Vector b)
    {
        return a.x * b.y - a.y * b.x;
    }
    /// <summary>内積</summary>
    static public double InnerProduct(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y;
    }
    #endregion

    #region operator
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.x - b.x, a.y - b.y);
    }

    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    #endregion

    public override bool Equals(object obj) => this == (Vector)obj;
    public override int GetHashCode() => (x.GetHashCode() * 11192916 + y.GetHashCode());

    public override string ToString() => $"{x} {y}";
}
#endregion
