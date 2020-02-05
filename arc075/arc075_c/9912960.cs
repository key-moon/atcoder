// detail: https://atcoder.jp/contests/arc075/submissions/9912960
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
using static Reader;

public static class P
{
    public static void Main()
    {
        var n = NextInt;
        var k = NextInt;
        var reducedA = new int[n];
        for (int i = 0; i < n; i++)
            reducedA[i] = NextInt - k;
        var accum = new long[n + 1];
        for (int i = 0; i < reducedA.Length; i++)
            accum[i + 1] = accum[i] + reducedA[i];
        //var compressDict = accum.Distinct().OrderBy(x => x).Select((elem, ind) => new Tuple { Item1 = elem, Item2 = ind }).ToDictionary(x => x.Item1, x => x.Item2);
        var distincted = accum.Distinct().ToArray();
        Array.Sort(distincted);
        long res = 0;
        BIT<int> bit = new BIT<int>(distincted.Length, 0, (x, y) => x + y);
        for (int i = 0; i < accum.Length; i++)
        {
            var ind = Array.BinarySearch(distincted, accum[i]);
            res += bit.Query(ind);
            bit.Operate(ind, 1);
        }
        Console.WriteLine(res);
    }
}

struct Tuple
{
    public long Item1;
    public int Item2;
}


class BIT<T>
{
    public readonly int Size;
    T Identity;
    T[] Elements;
    Func<T, T, T> Merge;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BIT(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Elements = new T[Size + 1];
        for (int i = 0; i < Elements.Length; i++) Elements[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int r)
    {
        T res = Identity;
        for (r++; r > 0; r -= r & -r) res = Merge(res, Elements[r]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        for (i++; i < Elements.Length; i += i & -i) Elements[i] = Merge(Elements[i], x);
    }
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
