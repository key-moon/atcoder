// detail: https://atcoder.jp/contests/atc001/submissions/8567384
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hw[0];
        int w = hw[1];
        var s = string.Join("", Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()));
        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }
        var startInd = s.IndexOf('s');
        var goalInd = s.IndexOf('g');
        bool[] canAchieve = new bool[h * w];
        Stack<int> stack = new Stack<int>();
        stack.Push(startInd);
        canAchieve[startInd] = true;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var item in graph[elem])
            {
                if (s[item] == '#' || canAchieve[item]) continue;
                canAchieve[item] = true;
                stack.Push(item);
            }
        }
        Console.WriteLine(canAchieve[goalInd] ? "Yes" : "No");
    }
}
