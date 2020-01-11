// detail: https://atcoder.jp/contests/dwacon6th-prelims/submissions/9425131
#undef DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
#if DEBUG
        var rng = new Random();
        int n = 10;
        var hate = Enumerable.Range(0, n).Select(x =>
        {
            while (true)
            {
                var res = rng.Next(0, n - 1);
                if (res != x) return res;
            }
        }).ToArray();
#else
        int n = int.Parse(Console.ReadLine());
        var hate = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
#endif
        if (n == 2)
        {
            Console.WriteLine(-1);
            return;
        }
        //残り全員に嫌われているカードがあれば組み込む
        //サイクリックヤバがあれば組み込む
        //嫌われを組み込むことでサイクリックが解決不能になることはあるか
        //ない:ある場合はサイクリックを組み込める
        RemoveablePriorityQueue<int> _cyclic = new RemoveablePriorityQueue<int>();
        bool[] resolved = new bool[n];
        int[] hatedCount = new int[n];
        for (int i = 0; i < n; i++)
        {
            hatedCount[hate[i]]++;
            if (hate[hate[i]] == i && i < hate[i])
            {
                _cyclic.Push(i);
                _cyclic.Push(hate[i]);
            }
        }
        
        HashSet<int>[] hateds = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();
        for (int i = 0; i < n; i++)
            hateds[hatedCount[i]].Add(i);

        RemoveablePriorityQueue<int> cands = new RemoveablePriorityQueue<int>();
        for (int i = 0; i < n; i++)
            cands.Push(i);
        int prevHated = -1;
        List<int> res = new List<int>();
        Action<int> add = x =>
        {
            res.Add(x);
            cands.Remove(x);
            hateds[hatedCount[x]].Remove(x);
            hatedCount[x] = -1;
            prevHated = hate[x];

            var xHate = hate[x];
            if (0 <= hatedCount[xHate])
            {
                hateds[hatedCount[xHate]].Remove(xHate);
                hatedCount[xHate]--;
                hateds[hatedCount[xHate]].Add(xHate);
            }

            if (!resolved[x] && !resolved[hate[x]] && x == hate[hate[x]])
            {
                _cyclic.Remove(x);
                _cyclic.Remove(hate[x]);
                resolved[x] = true;
                resolved[hate[x]] = true;
            }
        };

        for (int i = 0; i < n; i++)
        {
            int remainCount = n - i;
            if (hateds[remainCount - 1].Count != 0)
            {
                var target = hateds[remainCount - 1].First();
                add(target);
                continue;
            }
            if (remainCount == 3 && _cyclic.Count == 2)
            {
                var min = _cyclic.Top;
                if (min == prevHated)
                {
                    _cyclic.Remove(min);
                    var anotherMin = _cyclic.Top;
                    _cyclic.Push(min);
                    min = anotherMin;
                }
                add(min);
                continue;
            }
            var cand = cands.Top;
            if (prevHated == cand)
            {
                cands.Pop();
                var anotherCand = cands.Top;
                cands.Push(cand);
                cand = anotherCand;
            }
            add(cand);
        }
#if DEBUG
        Main();
#else
        Console.WriteLine(string.Join(" ", res.Select(x => x + 1)));
#endif
    }
}

class RemoveablePriorityQueue<T> where T : IComparable<T>, IEquatable<T>
{
    HashSet<T> elems = new HashSet<T>();
    private PriorityQueue<T> PQueue;
    private PriorityQueue<T> RemoveQueue;
    public RemoveablePriorityQueue()
    {
        PQueue = new PriorityQueue<T>();
        RemoveQueue = new PriorityQueue<T>();
    }
    public int Count => elems.Count;
    public T Top
    {
        get 
        {
            while (RemoveQueue.Count != 0 && PQueue.Count != 0 && RemoveQueue.Top.Equals(PQueue.Top))
            {
                RemoveQueue.Pop();
                PQueue.Pop();
            }
            if (PQueue.Count == 0) throw new Exception();
            return PQueue.Top;
        }
    }
    public T Pop()
    {
        var res = Top;
        PQueue.Pop();
        elems.Remove(res);
        return res;
    }
    public void Push(T elem)
    {
        if (!elems.Add(elem)) throw new Exception();
        PQueue.Push(elem);
    }
    public void Remove(T elem)
    {
        if (!elems.Remove(elem)) throw new Exception();
        RemoveQueue.Push(elem);
    }
}

class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool descendance = false) { Descendance = descendance; }
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
                if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
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
            if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
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

public struct Pair : IEquatable<Pair>
{
    public int A;
    public int B;
    public Pair(int a, int b)
    {
        if (a < b) { A = b; B = a; }
        else { A = a; B = b; }
    }

    public bool Equals(Pair other) => A == other.A && B == other.B;
    public override int GetHashCode() => A * B;
}
    
