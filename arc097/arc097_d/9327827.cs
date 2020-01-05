// detail: https://atcoder.jp/contests/arc097/submissions/9327827
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        List<int[]> edges = new List<int[]>();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            edges.Add(st);
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }
        var c = Console.ReadLine();
        var degrees = graph.Select(x => x.Count).ToArray();
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < degrees.Length; i++)
            if (degrees[i] == 1 && c[i] == 'B') stack.Push(i);
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            degrees[elem] = 0;
            foreach (var item in graph[elem])
            {
                if (degrees[item] != 0) degrees[item]--;
                if (degrees[item] == 1 && c[item] == 'B')
                {
                    stack.Push(item);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (degrees[i] == 0 && c[i] == 'W')
            {
                Console.WriteLine(1);
                return;
            }
        }
        var newedges = edges.Where(x => degrees[x[0]] > 0 && degrees[x[1]] > 0).ToArray();
        var compress = newedges.SelectMany(x => x).OrderBy(x => x).Distinct().Select((a, b) => new { a, b }).ToDictionary(x => x.a, x => x.b);
        var decompress = compress.Keys.OrderBy(x => x).ToArray();
        for (int i = 0; i < newedges.Length; i++)
        {
            newedges[i][0] = compress[newedges[i][0]];
            newedges[i][1] = compress[newedges[i][1]];
        }
        var rerooting = new ReRooting<Top2<int>>(compress.Count, newedges, default(Top2<int>), Top2<int>.Merge, (x, i) =>
        {
            var ind = decompress[i];
            var operationParity = degrees[ind] & 1;
            var neededParity = (c[ind] == 'W') ? 1 : 0;

            if (operationParity == neededParity) return x;
            else return new Top2<int>() { First = x.First + 1, Second = x.Second + 1 };
        });
        var res = 0;
        for (int i = 0; i < decompress.Length; i++)
        {
            var ind = decompress[i];
            var operationParity = degrees[ind] & 1;
            var neededParity = (c[ind] == 'W') ? 1 : 0;

            res += degrees[ind];
            if (operationParity != neededParity) res++;
        }
        var discount = decompress.Length == 0 ? 0 : Enumerable.Range(0, decompress.Length).Select(x =>
        {
            var queryRes = rerooting.Query(x);
            return queryRes.Second + queryRes.First;
        }).Max();
        Console.WriteLine(res - discount);
    }
}


struct Top2<T> where T : IComparable<T>
{
    public T First;
    public T Second;
    public Top2(T first, T second) { First = first; Second = second; }
    public static Top2<T> Merge(Top2<T> a, Top2<T> b)
    {
        if (a.First.CompareTo(b.First) > 0)
            return new Top2<T>(a.First, a.Second.CompareTo(b.First) > 0 ? a.Second : b.First);
        else
            return new Top2<T>(b.First, b.Second.CompareTo(a.First) > 0 ? b.Second : a.First);
    }
    public static Top2<T> Merge(Top2<T> a, T b)
    {
        if (a.Second.CompareTo(b) > 0) return a;
        if (a.First.CompareTo(b) > 0) return new Top2<T>(a.First, b);
        return new Top2<T>(b, a.First);
    }
    public static Top2<T> operator |(Top2<T> a, Top2<T> b) => Merge(a, b);
    public static Top2<T> operator |(Top2<T> a, T b) => Merge(a, b);
}


class ReRooting<T>
{
    public int NodeCount { get; private set; }

    int[][] Adjacents;
    int[][] IndexForAdjacent;

    T[] Res;
    T[][] DP;

    T Identity;
    Func<T, T, T> Operate;
    Func<T, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identity, Func<T, T, T> operate, Func<T, int, T> operateNode)
    {
        NodeCount = nodeCount;

        Identity = identity;
        Operate = operate;
        OperateNode = operateNode;

        List<int>[] adjacents = new List<int>[nodeCount];
        List<int>[] indexForAdjacents = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            adjacents[i] = new List<int>();
            indexForAdjacents[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForAdjacents[edge[0]].Add(adjacents[edge[1]].Count);
            indexForAdjacents[edge[1]].Add(adjacents[edge[0]].Count);
            adjacents[edge[0]].Add(edge[1]);
            adjacents[edge[1]].Add(edge[0]);
        }

        Adjacents = new int[nodeCount][];
        IndexForAdjacent = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Adjacents[i] = adjacents[i].ToArray();
            IndexForAdjacent[i] = indexForAdjacents[i].ToArray();
        }

        DP = new T[Adjacents.Length][];
        Res = new T[Adjacents.Length];

        for (int i = 0; i < Adjacents.Length; i++) DP[i] = new T[Adjacents[i].Length];
        if (NodeCount > 1) Initialize();
        else if (NodeCount == 1) Res[0] = OperateNode(Identity, 0);
    }

    public T Query(int node) => Res[node];

    private void Initialize()
    {
        int[] parents = new int[NodeCount];
        int[] order = new int[NodeCount];

        #region InitOrderedTree
        var index = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        parents[0] = -1;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            order[index++] = node;
            for (int i = 0; i < Adjacents[node].Length; i++)
            {
                var adjacent = Adjacents[node][i];
                if (adjacent == parents[node]) continue;
                stack.Push(adjacent);
                parents[adjacent] = node;
            }
        }
        #endregion

        #region fromLeaf
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            T accum = Identity;
            int parentIndex = -1;
            for (int j = 0; j < Adjacents[node].Length; j++)
            {
                if (Adjacents[node][j] == parent)
                {
                    parentIndex = j;
                    continue;
                }
                accum = Operate(accum, DP[node][j]);
            }
            DP[parent][IndexForAdjacent[node][parentIndex]] = OperateNode(accum, node);
        }
        #endregion

        #region toLeaf
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];
            T accum = Identity;
            T[] accumsFromTail = new T[Adjacents[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = Identity;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(DP[node][j], accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                DP[Adjacents[node][j]][IndexForAdjacent[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node);
                accum = Operate(accum, DP[node][j]);
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}
