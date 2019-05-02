// detail: https://atcoder.jp/contests/arc074/submissions/5234098
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        List<long> first = new List<long>();
        PriorityQueue<long> pqueue = new PriorityQueue<long>(false);
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            pqueue.Push(a[i]);
            sum += a[i];
        }
        first.Add(sum);
        for (int i = n; i < n * 2; i++)
        {
            pqueue.Push(a[i]);
            sum -= pqueue.Pop();
            sum += a[i];
            first.Add(sum);
        }
        List<long> last = new List<long>();
        pqueue = new PriorityQueue<long>(true);
        sum = 0;
        for (int i = n * 3 - 1; i >= n * 2; i--)
        {
            pqueue.Push(a[i]);
            sum += a[i];
        }
        last.Add(sum);
        for (int i = n * 2 - 1; i >= n; i--)
        {
            pqueue.Push(a[i]);
            sum -= pqueue.Pop();
            sum += a[i];
            last.Add(sum);
        }
        last.Reverse();
        Console.WriteLine(first.Zip(last, (x, y) => x - y).Max());
    }
}

class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool DoReverse;
    T[] data;
    public PriorityQueue(bool doReverse = false)
    {
        data = new T[65536];
        DoReverse = doReverse;
    }
    public T Top
    {
        get { return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if (index * 2 + 1 > Count)
            {
                if (index * 2 > Count) break;
                if (elem.CompareTo(data[index * 2]) > 0 ^ DoReverse)
                {
                    data[index] = data[index * 2];
                    index = index * 2;
                }
                else break;
            }
            else
            {
                var nextIndex = data[index * 2].CompareTo(data[index * 2 + 1]) <= 0 ^ DoReverse ? index * 2 : index * 2 + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ DoReverse)
                {
                    data[index] = data[nextIndex];
                    index = nextIndex;
                }
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    public void Push(T value)
    {
        Count++;
        if (data.Length == Count) Extend(data.Length * 2);
        int index = Count;
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ DoReverse)
            {
                data[index] = data[index >> 1];
                index >>= 1;
            }
            else break;
        }
        data[index] = value;
    }
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
}
