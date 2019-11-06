// detail: https://atcoder.jp/contests/abc035/submissions/8314816
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nmt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmt[0];
        var m = nmt[1];
        long t = nmt[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<Edge>[] edges = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        List<Edge>[] revedges = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            edges[abc[0] - 1].Add(new Edge() { From = abc[0] - 1, To = abc[1] - 1, Cost = abc[2] });
            revedges[abc[1] - 1].Add(new Edge() { From = abc[1] - 1, To = abc[0] - 1, Cost = abc[2] });
        }
        var res = Dijkstra(edges);
        var revres = Dijkstra(revedges);
        Console.WriteLine(a.Zip(res.Zip(revres, (x, y) => x + y), (x, y) => x * Max(0, t - y)).Max());
    }

    static long[] Dijkstra(List<Edge>[] graph)
    {
        bool[] arrived = new bool[graph.Length];
        long[] costs = Enumerable.Repeat(1L << 60, graph.Length).ToArray();
        PriorityQueue<Tuple<int, long>, long> pqueue = new PriorityQueue<Tuple<int, long>, long>(x => x.Item2);
        pqueue.Push(new Tuple<int, long>(0, 0));
        while (pqueue.Count > 0)
        {
            var elem = pqueue.Pop();
            var node = elem.Item1;
            var cost = elem.Item2;
            if (arrived[node]) continue;
            costs[node] = cost;
            arrived[node] = true;
            foreach (var neighbours in graph[node])
            {
                if (arrived[neighbours.To]) continue;
                pqueue.Push(new Tuple<int, long>(neighbours.To, cost + neighbours.Cost));
            }
        }
        return costs;
    }
}

struct Edge
{
    public int From;
    public int To;
    public long Cost;
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
