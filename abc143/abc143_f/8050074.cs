// detail: https://atcoder.jp/contests/abc143/submissions/8050074
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).GroupBy(x => x).Select(x => x.Count()).OrderByDescending(x => x).ToArray();
        PriorityQueue<int> groupes = new PriorityQueue<int>(true);
        var last = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < a[i] - last; j++)
                groupes.Push(i + 1);
            last = a[i];
        }
        int[] res = new int[n + 1];
        var lastRes = 0;
        var remain = 0;
        for (int i = n; i >= 1; i--)
        {
            int curRes = lastRes;
            while (groupes.Count != 0 && i <= groupes.Top + remain)
            {
                curRes++;
                remain -= i - groupes.Pop();
            }
            curRes += remain / i;
            remain %= i;
            res[i] = curRes;
            remain += curRes;
            lastRes = curRes;
            //Console.WriteLine($"{i} : {res[i]} remain:{remain}");
        }
        Console.WriteLine(string.Join("
", res.Skip(1)));
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
