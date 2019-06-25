// detail: https://atcoder.jp/contests/joi2008yo/submissions/6121849
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
        IntVector[] constellation = Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split().Select(int.Parse)).Select(x => new IntVector(x.First(), x.Last())).ToArray();
        HashSet<IntVector> stars = new HashSet<IntVector>(Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split().Select(int.Parse)).Select(x => new IntVector(x.First(), x.Last())));
        foreach (var origin in stars)
        {
            var distance = origin - constellation[0];
            foreach (var star in constellation)
            {
                if (!stars.Contains(distance + star)) goto invalid;
            }
            Console.WriteLine(distance);
            return;
        invalid:;
        }
    }
}


struct IntVector
{
    public long x;
    public long y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IntVector(long x, long y) { this.x = x; this.y = y; }
    public long this[int index]
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index == 0) return x; else return y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index == 0) x = value; else y = value; }
    }
    public long Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double CrossProduct(IntVector a, IntVector b) => a.x * b.y - a.y * b.x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public double InnerProduct(IntVector a, IntVector b) => a.x * b.x + a.y * b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntVector operator +(IntVector a, IntVector b) => new IntVector(a.x + b.x, a.y + b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntVector operator -(IntVector a, IntVector b) => new IntVector(a.x - b.x, a.y - b.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(IntVector a, IntVector b) => a.x == b.x && a.y == b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(IntVector a, IntVector b) => a.x != b.x || a.y != b.y;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => this == (IntVector)obj;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => x.GetHashCode() * 1000000007 + y.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"{x} {y}";
}
