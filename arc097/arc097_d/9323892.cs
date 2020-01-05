// detail: https://atcoder.jp/contests/arc097/submissions/9323892
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
        var rerooting = new ReRooting<Top2>(compress.Count, newedges, default(Top2), Top2.Merge, (x, i) =>
        {
            var ind = decompress[i];
            var operationParity = degrees[ind] & 1;
            var neededParity = (c[ind] == 'W') ? 1 : 0;

            if (operationParity == neededParity) return x;
            else return new Top2() { First = x.First + 1, Second = x.Second + 1 };
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

struct Top2
{
    public int First;
    public int Second;
    public static Top2 Merge(Top2 a, Top2 b)
    {
        int first, second;
        if (a.First > b.First)
        {
            first = a.First;
            second = a.Second > b.First ? a.Second : b.First;
        }
        else
        {
            first = b.First;
            second = b.Second > a.First ? b.Second : a.First;
        }
        return new Top2() { First = first, Second = second };
    }
}

class ReRooting<T>
{
    public int NodeCount { get; private set; }

    int[][] Neighbours;
    int[][] IndexForNeighbours;

    T[] Res;
    T[][] dp;

    T IdentityElement;
    Func<T, T, T> Operate;
    Func<T, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identityElement, Func<T, T, T> operate, Func<T, int, T> operateNode)
    {
        NodeCount = nodeCount;

        IdentityElement = identityElement;
        Operate = operate;
        OperateNode = operateNode;

        List<int>[] neighbours = new List<int>[nodeCount];
        List<int>[] indexForNeighbours = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            neighbours[i] = new List<int>();
            indexForNeighbours[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForNeighbours[edge[0]].Add(neighbours[edge[1]].Count);
            indexForNeighbours[edge[1]].Add(neighbours[edge[0]].Count);
            neighbours[edge[0]].Add(edge[1]);
            neighbours[edge[1]].Add(edge[0]);
        }

        Neighbours = new int[nodeCount][];
        IndexForNeighbours = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Neighbours[i] = neighbours[i].ToArray();
            IndexForNeighbours[i] = indexForNeighbours[i].ToArray();
        }

        dp = new T[Neighbours.Length][];
        Res = new T[Neighbours.Length];

        for (int i = 0; i < Neighbours.Length; i++) dp[i] = new T[Neighbours[i].Length];
        if (NodeCount > 1) Initialize();
        else if (NodeCount == 1) Res[0] = OperateNode(IdentityElement, 0);
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
            for (int i = 0; i < Neighbours[node].Length; i++)
            {
                var neighbour = Neighbours[node][i];
                if (neighbour == parents[node]) continue;
                stack.Push(neighbour);
                parents[neighbour] = node;
            }
        }
        #endregion

        #region fromLeaf
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            T accum = IdentityElement;
            int neighbourIndex = -1;
            for (int j = 0; j < Neighbours[node].Length; j++)
            {
                if (Neighbours[node][j] == parent)
                {
                    neighbourIndex = j;
                    continue;
                }
                accum = Operate(accum, dp[node][j]);
            }
            dp[parent][IndexForNeighbours[node][neighbourIndex]] = OperateNode(accum, node);
        }
        #endregion

        #region toLeaf
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];
            T accum = IdentityElement;
            T[] accumsFromTail = new T[Neighbours[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = IdentityElement;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(dp[node][j], accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                dp[Neighbours[node][j]][IndexForNeighbours[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node);
                accum = Operate(accum, dp[node][j]);
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}
