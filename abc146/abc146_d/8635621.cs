// detail: https://atcoder.jp/contests/abc146/submissions/8635621
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

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Edge>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        List<Edge> edges = new List<Edge>();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            var edge = new Edge() { From = st[0], To = st[1] };
            graph[st[0]].Add(edge);
            graph[st[1]].Add(edge);
            edges.Add(edge);
        }
        var col = graph.Max(x => x.Count);
        Console.WriteLine(col);

        Action<int, int, int> dfs = null;
        dfs = (node, from, fromColor) =>
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
        };
        dfs(0, int.MaxValue, -1);
        Console.WriteLine(string.Join("
", edges.Select(x => x.Color)));
    }
}

class Edge
{
    public int From;
    public int To;
    public int Color;
}
