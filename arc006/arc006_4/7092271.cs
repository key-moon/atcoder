// detail: https://atcoder.jp/contests/arc006/submissions/7092271
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        bool[][] s = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Select(x => x == 'o').ToArray()).ToArray();
        UnionFind uf = new UnionFind(h * w);

        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w - 1; j++)
            {
                if (s[i][j] && s[i + 1][j])
                    uf.TryUnite(i * w + j, (i + 1) * w + j);
                if (s[i][j] && s[i][j + 1])
                    uf.TryUnite(i * w + j, i * w + j + 1);
                if (s[i][j] && s[i + 1][j + 1])
                    uf.TryUnite(i * w + j, (i + 1) * w + j + 1);
                if (s[i][j + 1] && s[i + 1][j])
                    uf.TryUnite(i * w + j + 1, (i + 1) * w + j);
            }

        var squareSizes = uf.AllRepresents.Select(x => GetInitialSize(uf.GetSize(x))).ToArray();
        var a = squareSizes.Count(x => x == 12);
        var b = squareSizes.Count(x => x == 16);
        var c = squareSizes.Count(x => x == 11);
        Console.WriteLine($"{a} {b} {c}");
    }

    static int GetInitialSize(int size)
    {
        int i = 1;
        while (true)
        {
            if (size % (i * i) == 0 && size / (i * i) <= 20) return size / (i * i);
            i++;
        }
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
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
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
