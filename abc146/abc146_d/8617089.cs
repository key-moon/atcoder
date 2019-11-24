// detail: https://atcoder.jp/contests/abc146/submissions/8617089
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using static Reader;

public static class P
{
    static int col;
    static List<Edge>[] graph;
    public static void Main()
    {
        int n = NextInt;
        graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        List<Edge> edges = new List<Edge>();
        for (int i = 0; i < n - 1; i++)
        {
            var edge = new Edge() { From = NextInt - 1, To = NextInt - 1 };
            graph[edge.To].Add(edge);
            graph[edge.From].Add(edge);
            edges.Add(edge);
        }
        col = graph.Max(x => x.Count);
        Console.WriteLine(col);

        dfs(0, int.MaxValue, -1);
        Console.WriteLine(string.Join("
", edges.Select(x => x.Color)));
    }

    static void dfs(int node, int from, int fromColor)
    {
        int color = 1;
        for (int i = 0; i < graph[node].Count; i++)
        {
            var edge = graph[node][i];
            var to = edge.From ^ edge.To ^ node;
            if (to == from) continue;
            if (color == fromColor) color++;
            edge.Color = color;
            dfs(to, node, color);
            color++;
        }
    }
}

class Edge
{
    public int From;
    public int To;
    public int Color;
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = 0;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
