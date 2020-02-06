// detail: https://atcoder.jp/contests/abc138/submissions/9929173
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, nq[0]).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < nq[0] - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        var node = new long[nq[0]];
        for (int i = 0; i < nq[1]; i++)
        {
            var px = Console.ReadLine().Split().Select(int.Parse).ToArray();
            node[px[0] - 1] += px[1];
        }

        bool[] arrived = new bool[nq[0]];

        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            arrived[elem] = true;
            foreach (var item in graph[elem])
            {
                if (arrived[item]) continue;
                node[item] += node[elem];
                stack.Push(item);
            }
        }

        Console.WriteLine(string.Join(" ", node));
    }
}
