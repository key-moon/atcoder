// detail: https://atcoder.jp/contests/abc075/submissions/2092164
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] ab = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        int res = 0;
        for (int i = 0; i < ab.Length; i++)
        {
            UnionFind uf = new UnionFind(nm[0]);
            for (int j = 0; j < ab.Length; j++)
            {
                if (i != j) uf.Union(ab[j][0], ab[j][1]);
            }
            if (uf.AllParents().Length != 1) res++;
        }
        Console.WriteLine(res);
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
