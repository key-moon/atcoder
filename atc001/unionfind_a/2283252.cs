// detail: https://atcoder.jp/contests/atc001/submissions/2283252
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        UnionFind uf = new UnionFind(nq[0]);
        for (int i = 0; i < nq[1]; i++)
        {
            int[] pab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (pab[0] == 0)
            {
                uf.Union(pab[1], pab[2]);
            }
            else
            {
                Console.WriteLine(uf.IsSameGroup(pab[1], pab[2]) ? "Yes" : "No");
            }
        }
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
