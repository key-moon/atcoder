// detail: https://atcoder.jp/contests/abc020/submissions/6227611
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var hwt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwt[0];
        var w = hwt[1];
        var t = hwt[2];
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().ToArray()).ToArray();
        Tuple<int, int> start = null;
        Tuple<int, int> goal = null;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (map[i][j] == 'S')
                {
                    start = new Tuple<int, int>(i, j);
                    map[i][j] = '.';
                }
                if (map[i][j] == 'G')
                {
                    goal = new Tuple<int, int>(i, j);
                    map[i][j] = '.';
                }
            }
        }
        long valid = 1;
        long invalid = int.MaxValue / 2;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (GoalCost(map, mid, start, goal) <= t) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }

    static long GoalCost(char[][] map, long wallCost, Tuple<int, int> s, Tuple<int, int> g)
    {
        long[,] minCost = new long[map.Length, map[0].Length];
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                minCost[i, j] = long.MaxValue;
            }
        }
        PriorityQueue<Tuple<long, Tuple<int, int>>> pqueue = new PriorityQueue<Tuple<long, Tuple<int, int>>>();
        pqueue.Push(new Tuple<long, Tuple<int, int>>(0, s));
        while (pqueue.Count > 0)
        {
            var item = pqueue.Pop();
            if (item.Item1 >= minCost[item.Item2.Item1, item.Item2.Item2]) continue;
            minCost[item.Item2.Item1, item.Item2.Item2] = item.Item1;

            for (int i = 0; i < 4; i++)
            {
                var newPlace = new Tuple<int, int>(item.Item2.Item1 + ((i & 2) - 1) * (i & 1), item.Item2.Item2 + ((i & 2) - 1) * (~i & 1));
                if (newPlace.Item1 < 0 || map.Length <= newPlace.Item1 || newPlace.Item2 < 0 || map[0].Length <= newPlace.Item2)
                    continue;
                pqueue.Push(
                    new Tuple<long, Tuple<int, int>>(item.Item1 + (map[newPlace.Item1][newPlace.Item2] == '#' ? wallCost : 1), newPlace)
                );
            }
        }
        return minCost[g.Item1, g.Item2];
    }
}

class PriorityQueue<T> where T : IComparable
{
    public int Count { get; private set; }
    private bool DoReverse;
    private T[] data = new T[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool doReverse = false) { DoReverse = doReverse; }
    public T Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (elem.CompareTo(data[index << 1]) > 0 ^ DoReverse) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ DoReverse ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ DoReverse) data[index] = data[index = nextIndex];
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T value)
    {
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ DoReverse) data[index] = data[index >>= 1];
            else break;
        }
        data[index] = value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
}
