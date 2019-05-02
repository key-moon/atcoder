// detail: https://atcoder.jp/contests/arc074/submissions/5234669
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

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] first = new long[n + 1];
        PriorityQueue<long> pqueue = new PriorityQueue<long>(false);
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            var a = Read();
            pqueue.Push(a);
            sum += a;
        }
        first[0] = sum;
        long[] middle = new long[n];
        for (int i = 0; i < n; i++)
        {
            var a = Read();
            middle[i] = a;
            pqueue.Push(a);
            sum += a;
            sum -= pqueue.Pop();
            first[i + 1] = sum;
        }
        pqueue = new PriorityQueue<long>(true);
        sum = 0;
        for (int i = 0; i < n; i++)
        {
            var a = Read();
            pqueue.Push(a);
            sum += a;
        }
        long res = first[first.Length - 1] - sum;
        for (int i = middle.Length - 1; i >= 0; i--)
        {
            pqueue.Push(middle[i]);
            sum -= pqueue.Pop();
            sum += middle[i];
            res = Max(res, first[i] - sum);
        }
        Console.WriteLine(res);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Read()
    {
        long res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}

class PriorityQueue<T> where T : IComparable<T>
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
            if ((index << 1) + 1 > Count)
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
