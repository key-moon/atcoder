// detail: https://atcoder.jp/contests/aising2019/submissions/3988503
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hw[0];
        int w = hw[1];
        string[] map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        UnionFind uf = new UnionFind(h * w);
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w - 1; j++)
            {
                if (map[i][j] != map[i][j + 1]) uf.Unite(i * w + j, i * w + j + 1);
            }
        }
        for (int i = 0; i < h - 1; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (map[i][j] != map[i + 1][j]) uf.Unite(i * w + j, (i + 1) * w + j);
            }
        }

        var groups = uf.GetGroupes;
        long res = 0;
        foreach (var group in groups)
        {
            long c1 = 0;
            long c2 = 0;
            foreach (var elem in group)
            {
                
                int bh = elem / w;
                int bw = elem % w;
                if ((bh % 2 + bw % 2) % 2 == 0) c1++;
                else c2++;
            }
            c1.WriteLog();
            c2.WriteLog();
            res += c1 * c2;
        }
        res.WriteLine();
    }
}


class UnionFind
{
    int[] data;
    public UnionFind(int count)
    {
        data = Enumerable.Range(0, count).ToArray();
    }
    public void Unite(int x, int y)
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
    public IEnumerable<IEnumerable<int>> GetGroupes => data.Select((x, y) => new Tuple<int, int>(Parent(x), y)).GroupBy(x => x.Item1).Select(x => x.Select(y => y.Item2));
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

static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
