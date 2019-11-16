// detail: https://atcoder.jp/contests/abc145/submissions/8473157
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

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Vector[] vs = Enumerable.Repeat(0, n).Select(_ =>
        {
            var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Vector(v[0], v[1]);
        }).ToArray();
        var order = Enumerable.Range(0, n).ToArray();
        
        var sum = 0.0;
        var count = 0;
        do
        {
            for (int i = 0; i < order.Length - 1; i++)
            {
                sum += (vs[order[i + 1]] - vs[order[i]]).SqrtLength;
            }
            count++;
        } 
        while (Algorithm.NextPermutation(order));
        Console.WriteLine(sum / count);
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

class Algorithm
{
    public static void Swap<T>(ref T x, ref T y) { T tmp = x; x = y; y = tmp; }

    public static bool NextPermutation<T>(T[] array, int index, int length, Comparison<T> comp)
    {
        if (length <= 1) return false;
        for (int i = length - 1; i > 0; i--)
        {
            int k = i - 1;
            if (comp(array[k], array[i]) < 0)
            {
                int j = Array.FindLastIndex(array, delegate (T x) { return comp(array[k], x) < 0; });
                Swap(ref array[k], ref array[j]);
                Array.Reverse(array, i, length - i);
                return true;
            }
        }
        Array.Reverse(array, index, length);
        return false;
    }

    public static bool NextPermutation<T>(T[] array) where T : IComparable
    {
        return NextPermutation(array, 0, array.Length, Comparer<T>.Default.Compare);
    }
}
