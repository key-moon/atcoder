// detail: https://atcoder.jp/contests/abc123/submissions/4848410
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
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        HashSet<Tuple<int, int, int>> used = new HashSet<Tuple<int, int, int>>();
        var xyzk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        var c = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        PriorityQueue<Tuple<long, Tuple<int, int, int>>> pqueue = new PriorityQueue<Tuple<long, Tuple<int, int, int>>>(10000,1);
        pqueue.Push(new Tuple<long, Tuple<int, int, int>>(a[0] + b[0] + c[0], new Tuple<int, int, int>(0, 0, 0)));
        for (int i = 0; i < xyzk[3]; i++)
        {
            var item = pqueue.Pop();
            Console.WriteLine(item.Item1);
            if (item.Item2.Item1 < a.Length - 1)
            {
                var v = new Tuple<int, int, int>(item.Item2.Item1 + 1, item.Item2.Item2, item.Item2.Item3);
                if (!used.Contains(v))
                {
                    pqueue.Push(new Tuple<long, Tuple<int, int, int>>(item.Item1 - a[item.Item2.Item1] + a[item.Item2.Item1 + 1], v));
                    used.Add(v);
                }
            }
            if (item.Item2.Item2 < b.Length - 1)
            {
                var v = new Tuple<int, int, int>(item.Item2.Item1, item.Item2.Item2 + 1, item.Item2.Item3);
                if (!used.Contains(v))
                {
                    pqueue.Push(new Tuple<long, Tuple<int, int, int>>(item.Item1 - b[item.Item2.Item2] + b[item.Item2.Item2 + 1], v));
                    used.Add(v);
                }
            }
            if (item.Item2.Item3 < c.Length - 1)
            {
                var v = new Tuple<int, int, int>(item.Item2.Item1, item.Item2.Item2, item.Item2.Item3 + 1);
                if (!used.Contains(v))
                {
                    pqueue.Push(new Tuple<long, Tuple<int, int, int>>(item.Item1 - c[item.Item2.Item3] + c[item.Item2.Item3 + 1], v));
                    used.Add(v);
                }
            }
        }

    }
}

public class PriorityQueue<T> where T : IComparable
{
    private IComparer<T> _comparer = null;
    private int _type = 0;

    private T[] _heap;
    private int _sz = 0;

    private int _count = 0;

    /// <summary>
    /// Priority Queue with custom comparer
    /// </summary>
    public PriorityQueue(int maxSize, IComparer<T> comparer)
    {
        _heap = new T[maxSize];
        _comparer = comparer;
    }

    /// <summary>
    /// Priority queue
    /// </summary>
    /// <param name="maxSize">max size</param>
    /// <param name="type">0: asc, 1:desc</param>
    public PriorityQueue(int maxSize, int type = 0)
    {
        _heap = new T[maxSize];
        _type = type;
    }

    private int Compare(T x, T y)
    {
        if (_comparer != null) return _comparer.Compare(x, y);
        return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
    }

    public void Push(T x)
    {
        _count++;

        //node number
        var i = _sz++;

        while (i > 0)
        {
            //parent node number
            var p = (i - 1) / 2;

            if (Compare(_heap[p], x) <= 0) break;

            _heap[i] = _heap[p];
            i = p;
        }

        _heap[i] = x;
    }

    public T Pop()
    {
        _count--;

        T ret = _heap[0];
        T x = _heap[--_sz];

        int i = 0;
        while (i * 2 + 1 < _sz)
        {
            //children
            int a = i * 2 + 1;
            int b = i * 2 + 2;

            if (b < _sz && Compare(_heap[b], _heap[a]) < 0) a = b;

            if (Compare(_heap[a], x) >= 0) break;

            _heap[i] = _heap[a];
            i = a;
        }

        _heap[i] = x;

        return ret;
    }

    public int Count()
    {
        return _count;
    }

    public T Peek()
    {
        return _heap[0];
    }

    public bool Contains(T x)
    {
        for (int i = 0; i < _sz; i++) if (x.Equals(_heap[i])) return true;
        return false;
    }

    public void Clear()
    {
        while (this.Count() > 0) this.Pop();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var ret = new List<T>();

        while (this.Count() > 0)
        {
            ret.Add(this.Pop());
        }

        foreach (var r in ret)
        {
            this.Push(r);
            yield return r;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[_sz];
        int i = 0;

        foreach (var r in this)
        {
            array[i++] = r;
        }

        return array;
    }
}
