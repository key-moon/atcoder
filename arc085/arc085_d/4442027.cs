// detail: https://atcoder.jp/contests/arc085/submissions/4442027
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var bit = Console.ReadLine().Split().Select(int.Parse).ToList();
        var ruiseki = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            ruiseki[i + 1] = ruiseki[i] + bit[i];
        }
        int q = int.Parse(Console.ReadLine());
        var queries = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).OrderBy(x => x[0]).ToList();

        //開始地点でソートして、終了地点の中で最小を持つ。
        //遷移は、dp[i] := Min(dp[0..begin - 1] + score[begin..end], dp[begin] + score[begin + 1..end],dp[begin + 1] + score[begin + 2..end] ... dp[end - 1] + score[end..end]);
        //dp2[begin..end] :=  - score[0..end]
        //とすると、dp2[begin..end] + score[0..begin - 1] := 
        //改善を打ち消せるもの 要するに、そこまでを全て1で埋めたときのスコアを最初から持っておき、それに
        //score[a..b] := count0[a..b] - count1[a..b] == (b - a + 1) - count1[a..b] - count1[a..b]

        //そこがセクション終了だった時の最小スコアを保持します。
        //純粋にそこまでのminimum scoreを保持します。はじめは累積和の最後 := 1の数、ハミング符号の初期値が格納されています。
        SegmentTree<int> RMQ1 = new SegmentTree<int>(Enumerable.Repeat(ruiseki.Last(), n + 1).ToArray(), int.MaxValue, (x, y) => Min(x, y));
        //ある部分までが全て1になっているときのスコアを引いておきます。
        //RMQ[a..b]の結果にある場所までを全て1にした時のスコアを足すと、既に1の区間を0にした時のスコアが得られます。
        //そこまでを1にした時のスコアは、そこまでの0の個数と同値です。これは、区間長-1の数で求まります。
        //初期スコア
        SegmentTree<int> RMQ2 = new SegmentTree<int>(Enumerable.Repeat(int.MaxValue / 2, n + 1).ToArray(), int.MaxValue, (x, y) => Min(x, y));
        foreach (var query in queries)
        {
            int l = query[0];
            int r = query[1];
            //書き換える区間は、[l,r](1-indexed)
            //区間長
            int sectionLength = (r - l + 1);
            //ruiseki[a] := aまでの1の数 です
            int countSection1 = ruiseki[query[1]] - ruiseki[query[0] - 1];
            int countSection0 = sectionLength - countSection1;
            //update前はcount1だったものが、count0になります。つまり、このクエリにおけるスコア増減はcount0 - count1です。
            //これは式を整理すると、sectionLength - count1 * 2 となります。
            int sectionScore = countSection0 - countSection1;

            //区間の一つ前までの0の数です。これは余分に引かれているRMQ2の結果に足すために使われます。
            int untilBeginScore = (query[0] - 1) - ruiseki[query[0] - 1] * 2;

            //今回の区間を足すことで得られる最大スコアです。これを作用させます。
            var op = Min(RMQ1.Query(0, query[0] - 1) + sectionScore, RMQ2.Query(query[0], query[1]) + untilBeginScore + sectionScore);
            
            //RMQ1は前に
            RMQ1.Operate(query[1], op);
            RMQ2.Operate(query[1], op - (query[1] - ruiseki[query[1]] * 2));
        }
        Console.WriteLine(RMQ1.Query(0, RMQ1.Size - 1));
    }
}

class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(T[] elems, T identityElement ,Func<T, T, T> merge)
    {
        Size = elems.Length;
        Merge = merge;
        IdentityElement = identityElement;
        LeafCount = 1;
        while (LeafCount < elems.Length) LeafCount <<= 1;

        Data = new T[LeafCount * 2];
        elems.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 0; i--) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    public void Operate(int i, T x)
    {
        int ind = LeafCount + i;
        Data[LeafCount + i] = Merge(x, Data[LeafCount + i]);
        while (0 < (ind >>= 1))
        {
            Data[ind] = Merge(Data[ind * 2], Data[ind * 2 + 1]); 
        }
    }

    public T Query(int l, int r) => Query(l, r, 1, 0, LeafCount - 1);

    private T Query(int l, int r, int i, int x, int y)
    {
        if (y < l || r < x) return IdentityElement;
        if (l <= x && y <= r) return Data[i];
        return Merge(Query(l, r, i * 2, x, (x +  y) / 2), Query(l, r, i * 2 + 1, (x + y) / 2 + 1, y));
    }
}
