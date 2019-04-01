// detail: https://atcoder.jp/contests/dp/submissions/4793960
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
    int[][] Neighbours;
    int[][] IndexForNeighbours;

    long[] res;
    long[][] dp;
    int[] SearchState;

    public ReRooting(int nodeCount, int[][] edges)
    {
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
        SearchState = new int[Neighbours.Length];

        res = new long[Neighbours.Length];
        for (int i = 0; i < Neighbours.Length; i++)
        {
            dp[i] = new long[Neighbours[i].Length];
            SearchState[i] = -2;
        }
        if(nodeCount <= 1)
        {
            res[0] = 1;
            SearchState[0] = -1;
        }
    }

    public long Query(int x)
    {
        if (SearchState[x] != -1) DFS(x, -1);
        return res[x];
    }

    public long Query(int x, int toIndex)
    {
        if (SearchState[x] != -1 && SearchState[x] != toIndex) DFS(x, Neighbours[x][toIndex]);
        return dp[Neighbours[x][toIndex]][IndexForNeighbours[x][toIndex]];
    }

    private void DFS(int x, int parent)
    {
        Debug.Assert(SearchState[x] != -1 && (SearchState[x] == -2 || Neighbours[x][SearchState[x]] != parent));

        long accum = 1;
        if (SearchState[x] == -2)
        {
            SearchState[x] = -1;
            for (int i = 0; i < Neighbours[x].Length; i++)
            {
                if (Neighbours[x][i] == parent)
                {
                    SearchState[x] = i;
                    continue;
                }
                var state = SearchState[Neighbours[x][i]];
                if (state != -1 && state != IndexForNeighbours[x][i]) DFS(Neighbours[x][i], x);
                accum = (accum * dp[x][i]) % P.Mod;
            }
            if (SearchState[x] != -1)
            {
                dp[parent][IndexForNeighbours[x][SearchState[x]]] = accum + 1;
                return;
            }
            accum = 1;
        }
        else
        {
            var targetInd = SearchState[x];
            var target = Neighbours[x][targetInd];
            var targetState = SearchState[target];
            if (targetState != -1 && targetState != IndexForNeighbours[x][targetInd]) DFS(Neighbours[x][targetInd], x);
        }

        long[] accumsFromTail = new long[Neighbours[x].Length];
        accumsFromTail[accumsFromTail.Length - 1] = 1;
        for (int i = accumsFromTail.Length - 2; i >= 0; i--) accumsFromTail[i] = (accumsFromTail[i + 1] * dp[x][i + 1]) % P.Mod;
        for (int i = 0; i < accumsFromTail.Length; i++)
        {
            dp[Neighbours[x][i]][IndexForNeighbours[x][i]] = (accum * accumsFromTail[i]) % P.Mod + 1;
            accum = (accum * dp[x][i]) % P.Mod;
        }

        res[x] = accum;
        SearchState[x] = -1;
    }
}
