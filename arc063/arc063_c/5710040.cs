// detail: https://atcoder.jp/contests/arc063/submissions/5710040
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
        var edges = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        int k = int.Parse(Console.ReadLine());
        Node[] nodes = new Node[n];
        for (int i = 0; i < k; i++)
        {
            var vp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            nodes[vp[0] - 1] = new Node(vp[1] % 2 == 0 ? Parity.Even : Parity.Odd, vp[1], vp[1]);
        }
        var IdentityElement = new Node(Parity.Both, int.MinValue / 2, int.MaxValue / 2);
        ReRooting<Node> rerooting = new ReRooting<Node>(n, edges, IdentityElement, Node.Merge, Node.Next, (x, index) => Node.Merge(x, nodes[index] ?? IdentityElement));
        var res = new Node[n];
        for (int i = 0; i < n; i++)
        {
            var query = rerooting.Query(i);
            if (query.Parity == Parity.None || query.LowerBound > query.UpperBound || (query.LowerBound == query.UpperBound && ((query.Parity == Parity.Even) ^ query.LowerBound % 2 == 0))) goto invalid;
            res[i] = query;
        }
        Console.WriteLine("Yes");
        Console.WriteLine(string.Join("
", res.Select(x => x.UpperBound)));
        return;
    invalid:;
        Console.WriteLine("No");
    }
}

class Node
{
    public Parity Parity;
    public int UpperBound;
    public int LowerBound;
    public Node(Parity parity, int lowerBound, int upperBound)
    {
        Parity = parity;
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    public static Node Merge(Node a, Node b) => new Node(a.Parity & b.Parity, Max(a.LowerBound, b.LowerBound), Min(a.UpperBound, b.UpperBound));
    public static Node Next(Node x) => new Node(x.Parity == Parity.Even ? Parity.Odd : x.Parity == Parity.Odd ? Parity.Even : x.Parity, x.LowerBound - 1, x.UpperBound + 1);
    public override string ToString() => $"Parity : {Parity}, [{LowerBound},{UpperBound}]";
}

enum Parity
{
    None = 0,
    Odd = 1,
    Even = 2,
    Both = 3
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
    Func<T, T> Next;
    Func<T, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identityElement, Func<T, T, T> operate, Func<T, T> next, Func<T, int, T> operateNode)
    {
        NodeCount = nodeCount;

        IdentityElement = identityElement;
        Operate = operate;
        Next = next;
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
        else Res[0] = OperateNode(IdentityElement, 0);
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
            dp[parent][IndexForNeighbours[node][neighbourIndex]] = Next(OperateNode(accum, node));
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
                dp[Neighbours[node][j]][IndexForNeighbours[node][j]] = Next(OperateNode(Operate(accum, accumsFromTail[j]), node));
                accum = Operate(accum, dp[node][j]);
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}
