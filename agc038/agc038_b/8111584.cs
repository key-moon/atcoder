// detail: https://atcoder.jp/contests/agc038/submissions/8111584
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    static int h;
    static int w;
    static int a;
    static int b;
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 1;
        AggregationQueue<Incr> isIncr = new AggregationQueue<Incr>(Incr.Merge);
        AggregationQueue<int> rmin = new AggregationQueue<int>(Min);
        AggregationQueue<int> rmax = new AggregationQueue<int>(Max);

        for (int i = 0; i < k; i++)
        {
            isIncr.Push(new Incr() { L = p[i], R = p[i], Valid = true });
            rmin.Push(p[i]);
            rmax.Push(p[i]);
        }
        
        long incrCount = isIncr.Value.Valid ? 1 : 0;
        for (int i = k; i < n; i++)
        {
            var min = rmin.Value;
            
            isIncr.Push(new Incr() { L = p[i], R = p[i], Valid = true });
            isIncr.Pop();
            rmin.Push(p[i]);
            rmin.Pop();
            rmax.Push(p[i]);
            rmax.Pop();

            if (rmax.Value != p[i] || min != p[i - k])
            {
                if (isIncr.Value.Valid) incrCount++;
                res++;
            }
        }

        Console.WriteLine(res - (incrCount <= 1 ? 0 : incrCount - 1));
    }
}

struct Incr
{
    public bool Valid;
    public int L;
    public int R;
    public static Incr Merge(Incr a, Incr b) => a.Valid && b.Valid && a.R < b.L ? new Incr() { L = a.L, R = b.R, Valid = true } : new Incr { Valid = false };
}

class AggregationQueue<T>
{
    public int Count { get; private set; }
    public T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return
                TailValueStack.Count == 0 ? FrontValue :
                FrontIsEmpty ? TailValueStack.Peek() :
                Merge(TailValueStack.Peek(), FrontValue);
        }
    }

    bool FrontIsEmpty = true;
    T FrontValue;
    Stack<T> Fronts = new Stack<T>();
    Stack<T> TailValueStack = new Stack<T>();

    Func<T, T, T> Merge;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AggregationQueue(Func<T, T, T> merge)
    {
        Merge = merge;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Pop()
    {
        ValidateNotEmpty();
        if (TailValueStack.Count == 0) Move();
        TailValueStack.Pop();
        Count--;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T item)
    {
        Fronts.Push(item);
        Count++;
        FrontValue = FrontIsEmpty ? item : Merge(FrontValue, item);
        FrontIsEmpty = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Move()
    {
        TailValueStack.Push(Fronts.Pop());
        while (0 < Fronts.Count)
            TailValueStack.Push(Merge(Fronts.Pop(), TailValueStack.Peek()));
        FrontIsEmpty = true;
    }

    private void ValidateNotEmpty() { if (Count == 0) throw new Exception(); }
}

class MonoidAggregationQueue<T>
{
    public int Count { get; private set; }
    public T Value { get { return Merge(TailValueStack.Peek(), FrontValue); } }

    T FrontValue;
    Stack<T> Fronts = new Stack<T>();
    Stack<T> TailValueStack = new Stack<T>();

    Func<T, T, T> Merge;
    T Identity;
    
    public MonoidAggregationQueue(Func<T, T, T> merge, T identity)
    {
        Merge = merge;
        Identity = identity;
        TailValueStack.Push(identity);
    }

    public void Pop()
    {
        ValidateNotEmpty();
        if (TailValueStack.Count == 1) Move();
        TailValueStack.Pop();
        Count--;
    }

    public void Push(T item)
    {
        Fronts.Push(item);
        Count++;
        FrontValue = Merge(FrontValue, item);
    }

    private void Move()
    {
        TailValueStack.Push(Fronts.Pop());
        while (0 < Fronts.Count)
            TailValueStack.Push(Merge(Fronts.Pop(), TailValueStack.Peek()));
        FrontValue = Identity;
    }

    private void ValidateNotEmpty() { if (Count == 0) throw new Exception(); }
}
