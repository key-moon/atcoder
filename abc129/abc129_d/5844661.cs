// detail: https://atcoder.jp/contests/abc129/submissions/5844661
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var s = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        UnionFind[] columnUF = Enumerable.Repeat(0, h).Select(_ => new UnionFind(w)).ToArray();
        UnionFind[] rowUF = Enumerable.Repeat(0, w).Select(_ => new UnionFind(h)).ToArray();

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w - 1; j++)
            {
                if (s[i][j] == '#' || s[i][j + 1] == '#') continue;
                columnUF[i].TryUnite(j, j + 1);
            }
        }

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h - 1; j++)
            {
                if (s[j][i] == '#' || s[j + 1][i] == '#') continue;
                rowUF[i].TryUnite(j, j + 1);
            }
        }

        int max = 0;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (s[i][j] != '.') continue;
                max = Max(max, columnUF[i].GetSize(j) + rowUF[j].GetSize(i));
            }
        }
        Console.WriteLine(max - 1);
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
