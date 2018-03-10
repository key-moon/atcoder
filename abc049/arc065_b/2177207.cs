// detail: https://atcoder.jp/contests/abc049/submissions/2177207
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
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
            road.Union(ab[0], ab[1]);
        }
        for (int i = 0; i < nkl[2]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            train.Union(ab[0], ab[1]);
        }

        int[] roadd = road.formatData();
        int[] traind = train.formatData();
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
    public int[] formatData() => data.Select(x => Parent(x)).ToArray();
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
