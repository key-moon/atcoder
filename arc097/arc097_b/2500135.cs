// detail: https://atcoder.jp/contests/arc097/submissions/2500135
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //1~nまでを並び替えた
        int[] p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        //規定の並び替え動作を複数回行い、12345と一致している数を最大化
        Pair[] ps = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).OrderBy(x => x).ToArray()).Select(x => new Pair(x[0], x[1])).ToArray();
        //同じグループに属している奴らは自由に並び替え可能
        //席と数字が与えられ、マッチング
        UnionFind uf = new UnionFind(nm[0]);
        foreach (var item in ps)
        {
            uf.Union(item.x, item.y);
        }
        //親,(親にひっついてる数,親達の席)
        Dictionary<int, Tuple<List<int>, List<int>>> dict = new Dictionary<int, Tuple<List<int>, List<int>>>();
        for (int i = 0; i < nm[0]; i++)
        {
            int parent = uf.Parent(i);
            if (!dict.ContainsKey(parent)) dict.Add(parent, new Tuple<List<int>, List<int>>(new List<int>(), new List<int>()));
            dict[parent].Item1.Add(p[i]);
            dict[parent].Item2.Add(i);
        }
        int count = 0;
        foreach (var item in dict.Values)
        {
            count += item.Item1.Intersect(item.Item2).Count();
        }
        Console.WriteLine(count);
    }
}


class UnionFind
{
    int[] data;
    public UnionFind(int count)
    {
        data = Enumerable.Range(0, count).ToArray();
    }
    public void Union(int x, int y)
    {
        int xp = Parent(x);
        int yp = Parent(y);
        if (xp != yp)
        {
            data[yp] = xp;
        }
    }
    public bool IsSameGroup(int x, int y) => Parent(x) == Parent(y);
    public int[] AllParents() => data.Where((x, y) => x == y).ToArray();
    public int Parent(int x)
    {
        form(x);
        return data[x];
    }
    private void form(int x)
    {
        while (data[x] != data[data[x]])
        {
            data[x] = data[data[x]];
        }
    }
}

struct Pair
{
    public int x;
    public int y;

    public Pair(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
