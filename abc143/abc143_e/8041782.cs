// detail: https://atcoder.jp/contests/abc143/submissions/8041782
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nml = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nml[0];
        var m = nml[1];
        var l = nml[2];
        
        int[][] arriveCost = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(l + 1, n).ToArray()).ToArray();

        List<Tuple<int, int>>[] neighbours = Enumerable.Repeat(0, n).Select(_ => new List<Tuple<int, int>>()).ToArray();
        for (int i = 0; i < n; i++)
            arriveCost[i][i] = 0;

        for (int i = 0; i < m; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = abc[0] - 1;
            var b = abc[1] - 1;
            var c = abc[2];
            arriveCost[a][b] = Min(arriveCost[a][b], c);
            arriveCost[b][a] = Min(arriveCost[b][a], c);
        }

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    arriveCost[j][k] = Min(arriveCost[j][k], arriveCost[j][i] + arriveCost[i][k]);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                arriveCost[i][j] = arriveCost[i][j] <= l ? 1 : int.MaxValue / 2;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    arriveCost[j][k] = Min(arriveCost[j][k], arriveCost[j][i] + arriveCost[i][k]);

        StringBuilder builder = new StringBuilder();
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var st = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = st[0] - 1;
            var t = st[1] - 1;
            builder.AppendLine((int.MaxValue / 2 == arriveCost[s][t] ? -1 : arriveCost[s][t] - 1).ToString());
        }
        Console.WriteLine(builder.ToString());
    }
}


class PriorityQueue<TValue, TKey> where TKey : IComparable<TKey>
{
    public int Count { get; private set; }
    private Func<TValue, TKey> KeySelector;
    private bool Descendance;
    private TValue[] data = new TValue[65536];
    private TKey[] keys = new TKey[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(Func<TValue, TKey> keySelector, bool descendance = false)
    { KeySelector = keySelector; Descendance = descendance; }
    public TValue Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TValue Pop()
    {
        var top = Top;
        var item = data[Count--];
        var key = KeySelector(item);
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (key.CompareTo(keys[index << 1]) > 0 ^ Descendance)
                { data[index] = data[index << 1]; keys[index] = keys[index << 1]; index <<= 1; }
                else break;
            }
            else
            {
                var nextIndex = keys[index << 1].CompareTo(keys[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (key.CompareTo(keys[nextIndex]) > 0 ^ Descendance)
                { data[index] = data[nextIndex]; keys[index] = keys[nextIndex]; index = nextIndex; }
                else break;
            }
        }
        data[index] = item;
        keys[index] = key;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(TValue item)
    {
        var key = KeySelector(item);
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (keys[index >> 1].CompareTo(key) > 0 ^ Descendance)
            { data[index] = data[index >> 1]; keys[index] = keys[index >> 1]; index >>= 1; }
            else break;
        }
        data[index] = item;
        keys[index] = key;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        TValue[] newData = new TValue[newSize];
        TKey[] newKeys = new TKey[newSize];
        data.CopyTo(newData, 0);
        keys.CopyTo(newKeys, 0);
        data = newData;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new IndexOutOfRangeException(); }
}
