// detail: https://atcoder.jp/contests/abc131/submissions/6074491
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
        var n = int.Parse(Console.ReadLine());
        //グループに属している点にはグループ番号を割り振る
        //y軸で走査
        //点群の位置で止まる
        //新しくグループを作る
        //それらを
        //点が属しているグループを併合する  併合時にx軸が衝突したらres--
        //最終的に下に来たものの個数=unique じゃん
        //この時グループの持っている縦カウントを合計
        //自分のぶんとして+1する
        int[] yCounts = new int[100001];
        UnionFind uf = new UnionFind(100001);
        var points = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => new Point(x[1], x[0])).ToArray();
        foreach (var pointBundle in points.GroupBy(x => x.Y).OrderBy(x => x.Key))
        {
            var represent = pointBundle.First();
            var ySum = yCounts[uf.Find(represent.X)];
            foreach (var point in pointBundle)
            {
                //別グループだったらadd
                if (uf.Find(represent.X) != uf.Find(point.X))
                {
                    ySum += yCounts[uf.Find(point.X)];
                    uf.TryUnite(represent.X, point.X);
                }
            }
            //自分のぶん
            ySum += 1;
            yCounts[uf.Find(represent.X)] = ySum;
        }
        long sum = 0;
        long count = 0;
        foreach (var item in uf.AllRepresents)
        {
            sum += ((long)uf.GetSize(item) - 1) * (yCounts[item] - 1);
            count += uf.GetSize(item) + yCounts[item] - 1;
        }
        Console.WriteLine(sum - (n - count));
    }
}

struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
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
