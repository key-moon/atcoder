// detail: https://atcoder.jp/contests/diverta2019-2/submissions/5934971
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        long n = Read();
        var ga = Read();
        var sa = Read();
        var ba = Read();
        var gb = Read();
        var sb = Read();
        var bb = Read();
        n = Solve(n, new IntTuple(ga, gb), new IntTuple(sa, sb), new IntTuple(ba, bb));
        n = Solve(n, new IntTuple(gb, ga), new IntTuple(sb, sa), new IntTuple(bb, ba));
        Console.WriteLine(n);
    }

    //向こうのレートでどれくらいにできるか
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Solve(long n, IntTuple g, IntTuple s , IntTuple b)
    {
        if (g.Item1 >= g.Item2) return Solve(n, s, b);
        if (s.Item1 >= s.Item2) return Solve(n, g, b);
        if (b.Item1 >= b.Item2) return Solve(n, g, s);
        long max = 0;
        long currentEffort = 0;
        while (n >= 0)
        {
            max = Max(max, currentEffort + Solve(n, g, s));
            n -= b.Item1;
            currentEffort += b.Item2;
        }
        return max;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Solve(long n, IntTuple g, IntTuple s)
    {
        if (g.Item1 >= g.Item2) Solve(n, s);
        if (s.Item1 >= s.Item2) Solve(n, g);
        long max = 0;
        long currentEffort = 0;
        while (n >= 0)
        {
            max = Max(max, currentEffort + Solve(n, g));
            n -= s.Item1;
            currentEffort += s.Item2;
        }
        return max;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Solve(long n, IntTuple g)
    {
        if (g.Item1 >= g.Item2) return n;
        return n % g.Item1 + (n / g.Item1) * g.Item2;
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
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

struct IntTuple
{
    public int Item1;
    public int Item2;
    public IntTuple (int item1, int item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}
