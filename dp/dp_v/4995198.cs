// detail: https://atcoder.jp/contests/dp/submissions/4995198
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    public static int Mod;
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        Mod = nm[1];
        List<int>[] neighbours = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        int[][] edges = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        ReRooting treeDP = new ReRooting(n, edges);
        Console.WriteLine(string.Join("
", Enumerable.Range(0, n).Select(x => treeDP.Query(x))));
    }
}


class ReRooting
{
    public int NodeCount { get; private set; }

    int[][] Neighbours;
    int[][] IndexForNeighbours;

    long[] Res;
    long[][] dp;
    public ReRooting(int nodeCount, int[][] edges)
    {
        NodeCount = nodeCount;
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

        dp = new long[Neighbours.Length][];
        Res = new long[Neighbours.Length];

        for (int i = 0; i < Neighbours.Length; i++) dp[i] = new long[Neighbours[i].Length];
        if (NodeCount > 1) Initialize();
        else Res[0] = 1;
    }

    public long Query(int x) => Res[x];

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
        //DFSの逆順に辿ると、親に対して値を返すために必要な情報は既に集まっている。
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            long accum = 1;
            int neighbourIndex = -1;
            for (int j = 0; j < Neighbours[node].Length; j++)
            {
                if (Neighbours[node][j] == parent)
                {
                    neighbourIndex = j;
                    continue;
                }
                //部分木の結果を累積
                accum = (accum * dp[node][j]) % P.Mod;
            }
            //自ノードの値を作用させ、dpに保持させる
            dp[parent][IndexForNeighbours[node][neighbourIndex]] = accum + 1;
        }
        #endregion

        #region toLeaf
        //既にノードの値を出すために必要な情報は集まっているので、出す
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];

            long accum = 1;

            //尻からの累積
            long[] accumsFromTail = new long[Neighbours[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = 1;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = (accumsFromTail[j] * dp[node][j]) % P.Mod;

            //頭から累積をしながら配る
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                dp[Neighbours[node][j]][IndexForNeighbours[node][j]] = (accum * accumsFromTail[j]) % P.Mod + 1;
                accum = (accum * dp[node][j]) % P.Mod;
            }
            //累積し終えたものにノードの値を作用させたものが結果(今回はなし)
            Res[node] = accum;
        }
        #endregion
    }
}
