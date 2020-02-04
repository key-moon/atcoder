// detail: https://atcoder.jp/contests/abc127/submissions/9896539
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        PriorityQueue<long> small = new PriorityQueue<long>((x, y) => x + y, x => -x, true);
        PriorityQueue<long> large = new PriorityQueue<long>((x, y) => x + y, x => -x);
        long? middle = null;
        long offset = 0;
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 2)
            {
                var pos = middle == null ? small.Top : middle;
                var val = offset + (large.Value - pos * large.Count) + (pos * small.Count - small.Value);
                Console.WriteLine($"{pos} {val}");
            }
            else
            {
                if (middle == null)
                {
                    small.Push(query[1]);
                    large.Push(small.Pop());
                    middle = large.Pop();
                }
                else
                {
                    small.Push(query[1]);
                    small.Push((int)middle);
                    large.Push(small.Pop());
                    middle = null;
                }
                offset += query[2];
            }
        }
    }
}


class PriorityQueue<T> where T : IComparable<T>
{
    public T Value{ get; private set; }
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[65536];
    private Func<T, T, T> Merge;
    private Func<T, T> GetInv;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(Func<T, T, T> merge, Func<T, T> getInv, bool descendance = false) { Descendance = descendance; Merge = merge; GetInv = getInv; }
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
        Value = Merge(Value, GetInv(top));
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
        Value = Merge(Value, value);
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
