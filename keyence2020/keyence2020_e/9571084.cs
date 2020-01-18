// detail: https://atcoder.jp/contests/keyence2020/submissions/9571084
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
using static System.Math;

public static class P
{
    public static void Main()
    {

        Action abort = () => { Console.WriteLine(-1); Environment.Exit(0); };

        const int INF = (int)1e9;

        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var d = Console.ReadLine().Split().Select(int.Parse).ToArray();

        char[] color = Enumerable.Repeat(' ', n).ToArray();
        int[] weights = new int[m];

        var wXorb = 'W' ^ 'B';

        Stack<int> stack = new Stack<int>();

        List<Edge>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            var s = st[0];
            var t = st[1];
            graph[st[0]].Add(new Edge() { ID = i, To = st[1] });
            graph[st[1]].Add(new Edge() { ID = i, To = st[0] });

            if (d[s] == d[t])
            {
                if (color[s] == ' ' && color[t] == ' ')
                {
                    color[s] = 'B';
                    color[t] = 'W';
                    stack.Push(s);
                    stack.Push(t);
                }
                else if (color[s] == ' ')
                {
                    color[s] = (char)(color[t] ^ wXorb);
                    stack.Push(s);
                }
                else if (color[t] == ' ')
                {
                    color[t] = (char)(color[s] ^ wXorb);
                    stack.Push(t);
                }
                else { }
                weights[i] = d[s];
            }
        }

        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            var curCost = d[elem];
            foreach (var edge in graph[elem])
            {
                if (weights[edge.ID] != 0) continue;
                if (color[edge.To] != ' ' || d[edge.To] < curCost)
                {
                    weights[edge.ID] = INF;
                    continue;
                }
                weights[edge.ID] = d[edge.To] - curCost;
                color[edge.To] = color[elem];
                stack.Push(edge.To);
            }
        }

        if (color.Any(x => x == ' ') || weights.Any(x => x == 0))
        {
            abort();
        }

        Console.WriteLine(string.Join("", color));
        Console.WriteLine(string.Join("
", weights));
    }
}

struct Edge
{
    public int ID;
    public int To;
}
