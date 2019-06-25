// detail: https://atcoder.jp/contests/joi2007ho/submissions/6121208
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool[,] map = new bool[5001, 5001];
        var pillars = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse)).Select(x => new IntVector(x.First(), x.Last())).ToArray();
        foreach (var pillar in pillars)
            map[pillar[0], pillar[1]] = true;
        long max = 0;
        foreach (var pillar1 in pillars)
            foreach (var pillar2 in pillars)
            {
                var diff = pillar2 - pillar1;
                var v = new IntVector(-diff.y, diff.x);
                var p1 = pillar1 + v;
                var p2 = pillar2 + v;
                var m1 = pillar1 - v;
                var m2 = pillar2 - v;
                if ((0 <= p1[0] && p1[0] < 5001 && 0 <= p1[1] && p1[1] < 5001 &&
                     0 <= p2[0] && p2[0] < 5001 && 0 <= p2[1] && p2[1] < 5001 && map[p1[0], p1[1]] && map[p2[0], p2[1]]) || 
                    (0 <= m1[0] && m1[0] < 5001 && 0 <= m1[1] && m1[1] < 5001 &&
                     0 <= m2[0] && m2[0] < 5001 && 0 <= m2[1] && m2[1] < 5001 && map[m1[0], m1[1]] && map[m2[0], m2[1]]))
                    max = Max(max, v[0] * v[0] + v[1] * v[1]);
            }
        Console.WriteLine(max);
    }
}

struct IntVector
{
    public long x;
    public long y;
    public long this[int index]
    {
        get { if (index == 0) return x; else return y; }
        set { if (index == 0) x = value; else y = value; }
    }
    public long Length => x * x + y * y;
    public double SqrtLength => Math.Sqrt(Length);
    public IntVector(long x, long y) { this.x = x; this.y = y; }
    static public double CrossProduct(IntVector a, IntVector b) => a.x * b.y - a.y * b.x;
    static public double InnerProduct(IntVector a, IntVector b) => a.x * b.x + a.y * b.y;
    public static IntVector operator +(IntVector a, IntVector b) => new IntVector(a.x + b.x, a.y + b.y);
    public static IntVector operator -(IntVector a, IntVector b) => new IntVector(a.x - b.x, a.y - b.y);
    public static bool operator ==(IntVector a, IntVector b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(IntVector a, IntVector b) => a.x != b.x || a.y != b.y;
    public override bool Equals(object obj) => this == (IntVector)obj;
    public override int GetHashCode() => x.GetHashCode() * 1000000007 + y.GetHashCode();
    public override string ToString() => $"{x} {y}";
}
