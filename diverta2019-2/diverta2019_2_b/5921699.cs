// detail: https://atcoder.jp/contests/diverta2019-2/submissions/5921699
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
        var n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        var xy = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new Tuple<long, long>(x[0], x[1])).OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToArray();
        HashSet<Tuple<long, long>> set = new HashSet<Tuple<long, long>>(xy);
        var candidate = xy.SelectMany(x => xy.Select(y => new Tuple<long, long>(x.Item1 - y.Item1, x.Item2 - y.Item2))).Distinct().ToArray();

        int min = int.MaxValue;
        foreach (var cand in candidate)
        {
            if (cand.Item1 == 0 && cand.Item2 == 0) continue;
            var res = 0;
            foreach (var point in xy)
            {
                if (set.Contains(new Tuple<long, long>(point.Item1 - cand.Item1, point.Item2 - cand.Item2))) continue;
                res++;
            }
            min = Min(min, res);
        }
        Console.WriteLine(min);
    }
}

class UnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    List<int> Sizes;
    List<int> Parent;
    public UnionFind(int count)
    {
        Size = 0;
        GroupCount = 0;
        Parent = new List<int>(count);
        Sizes = new List<int>(count);
        ExtendSize(count);
    }
    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        GroupCount--;
        Parent[yp] = xp;
        Sizes[xp] += Sizes[yp];
        return true;
    }
    public IEnumerable<int> AllRepresents => Parent.Where(x => x == Parent[x]);
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x])
        {
            Parent[x] = Parent[Parent[x]];
            x = Parent[x];
        }
        return x;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ExtendSize(int treeSize)
    {
        if (treeSize <= Size) return;
        Parent.Capacity = treeSize;
        Sizes.Capacity = treeSize;
        while (Size < treeSize)
        {
            Parent.Add(Size);
            Sizes.Add(1);
            Size++;
            GroupCount++;
        }
    }
}
