// detail: https://atcoder.jp/contests/abc137/submissions/9359861
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = NextInt;
        var m = NextInt;
        var p = NextInt;

        List<Edge>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        List<Edge>[] revGraph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var s = NextInt - 1;
            var t = NextInt - 1;
            var c = NextInt;
            graph[s].Add(new Edge() { To = t, Cost = c - p });
            revGraph[t].Add(new Edge() { To = s, Cost = c - p });
        }
        var isAchivable = IsAchivable(graph, 0).Zip(IsAchivable(revGraph, n - 1), (x, y) => x & y).ToArray();
        long[] maxScore = Enumerable.Repeat(long.MinValue / 2, n).ToArray();
        maxScore[0] = 0;
        for (int _ = 0; _ < n; _++)
        {
            bool updated = false;
            for (int i = 0; i < n; i++)
            {
                if (!isAchivable[i]) continue;
                var max = revGraph[i].Count != 0 ? revGraph[i].Select(x => maxScore[x.To] + x.Cost).Max() : long.MinValue;
                if (maxScore[i] < max)
                {
                    updated = true;
                    maxScore[i] = max;
                }
            }
            if (!updated) goto end;
        }
        Console.WriteLine(-1);
        return;
        end:;
        Console.WriteLine(Max(0, maxScore.Last()));
    }

    static bool[] IsAchivable(List<Edge>[] graph, int start)
    {
        bool[] res = new bool[graph.Length];
        Stack<int> stack = new Stack<int>();
        stack.Push(start);
        res[start] = true;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var item in graph[elem])
            {
                if (res[item.To]) continue;
                res[item.To] = true;
                stack.Push(item.To);
            }
        }
        return res;
    }
}

struct Edge
{
    public int To;
    public int Cost;
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
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
