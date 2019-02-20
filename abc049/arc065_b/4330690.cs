// detail: https://atcoder.jp/contests/abc049/submissions/4330690
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nkl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        UnionFind road = new UnionFind(nkl[0]);
        UnionFind train = new UnionFind(nkl[0]);
        for (int i = 0; i < nkl[1]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            road.Unite(ab[0], ab[1]);
        }
        for (int i = 0; i < nkl[2]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            train.Unite(ab[0], ab[1]);
        }

        int[] roadd = Enumerable.Range(0, road.Size).Select(x => road.Find(x)).ToArray();
        int[] traind = Enumerable.Range(0, train.Size).Select(x => train.Find(x)).ToArray();
        //<道路グループindex,<電車グループインデックス,属してるインデックス>>
        Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
        for (int i = 0; i < roadd.Length; i++)
        {
            if (!dict.ContainsKey(roadd[i])) dict.Add(roadd[i], new Dictionary<int, int>());
            if (!dict[roadd[i]].ContainsKey(traind[i])) dict[roadd[i]].Add(traind[i], 0);
            dict[roadd[i]][traind[i]]++;
        }
        Console.WriteLine(string.Join(" ", Enumerable.Range(0, nkl[0]).Select(x => dict[roadd[x]][traind[x]]).ToArray()));
    }
}

class UnionFind
{
    public int Size { get; private set; }
    List<int> parent;
    List<int> sizes;
    public UnionFind()
    {
        Size = 0;
        parent = new List<int>(65536);
        sizes = new List<int>(65536);
    }
    public UnionFind(int count)
    {
        Size = 0;
        parent = new List<int>(count);
        sizes = new List<int>(count);
        ExtendSize(count);
    }
    public bool Unite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (sizes[xp] < sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        parent[yp] = xp;
        sizes[xp] += sizes[yp];
        return true;
    }
    public IEnumerable<int> AllParents => parent.Where(x => x == parent[x]);
    public int GetSize(int x)
    {
        ExtendSize(x + 1);
        return sizes[x];
    }
    public bool IsSameGroup(int x, int y) => Find(x) == Find(y);
    public int Find(int x)
    {
        ExtendSize(x + 1);
        return parent[x] == parent[parent[x]] ? parent[x] : parent[x] = Find(parent[x]);
    }
    public void ExtendSize(int treeSize)
    {
        while (Size < treeSize)
        {
            parent.Add(Size);
            sizes.Add(1);
            Size++;
        }
    }
}
