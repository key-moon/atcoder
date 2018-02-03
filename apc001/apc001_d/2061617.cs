// detail: https://atcoder.jp/contests/apc001/submissions/2061617
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        MaxUnionFind muf = new MaxUnionFind(nm[0], a);
        for (long i = 0; i < nm[1]; i++)
        {
            long[] xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
            muf.Union(xy[0],xy[1]);
        }
        long[] min = muf.Min;
        long res = 0;
        if (min.Length == 1)
        {
            res = 0;
        }
        else if (a.Length - min.Length < min.Length - 2)
        {
            res = -1;
        }
        else
        {
            long[] q = min.OrderBy(x => x).ToArray();
            long[] p = a.OrderBy(x => x).ToArray();
            long[] r = new long[p.Length - q.Length];

            int index = 0;
            for (int i = 0; i < min.Length - 2; i++)
            {
                while (index < q.Length && p[i + index] == q[index]) index++;
                r[i] = p[i + index];
            }
            res = r.Sum() + min.Sum();
        }
        Console.WriteLine(res != -1 ? $"{res}" : "Impossible");
    }
    static void e()
    {
        throw new ArgumentException();
    }
}
class MaxUnionFind
{
    ufData[] data;
    public long[] Min => data.Where((x, y) => x.Parent == y).Select(x => x.Data).ToArray();
    public MaxUnionFind(int count,long[] d)
    {
        data = Enumerable.Range(0, count).Select(x => new ufData(x, d[x])).ToArray();
    }
    public void Union(long x, long y)
    {
        long xp = Parent(x);
        long yp = Parent(y);
        long xd = data[xp].Data;
        long yd = data[yp].Data;
        if (xp != yp)
        {
            data[yp].Parent = xp;
            data[xp].Data = Math.Min(xd,yd);
        }
        data[yp].Parent = xp;
    }
    public bool IsSameGroup(long x, long y) => Parent(x) == Parent(y);
    public long Parent(long x)
    {
        form(x);
        return data[x].Parent;
    }
    public long Data(long x)
    {
        form(x);
        return data[data[x].Parent].Data;
    }
    private void form(long x)
    {
        while (data[data[x].Parent].Parent != data[x].Parent)
        {
            data[x].Parent = data[data[x].Parent].Parent;
        }
    }
    struct ufData
    {
        public long Parent { get; set; }
        public long Data { get; set; }
        public ufData(long parents, long data)
        {
            Parent = parents;
            Data = data;
        }
    }
}
