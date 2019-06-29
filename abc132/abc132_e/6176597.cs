// detail: https://atcoder.jp/contests/abc132/submissions/6176597
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[] neighbors = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var uv = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            neighbors[uv[0]].Add(uv[1]);
        }
        var sg = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        var s = sg[0];
        var g = sg[1];
        bool[][] arrived = new bool[][]
        {
            new bool[n],
            new bool[n],
            new bool[n]
        };
        arrived[0][s] = true;
        List<int> nextVertexes = new List<int>() { s };
        for (int iteration = 1; ; iteration++)
        {
            for (int hop = 0; hop < 3; hop++)
            {
                var newNext = new List<int>();
                var nextPlace = (hop + 1) % 3;
                foreach (var vertex in nextVertexes)
                {
                    foreach (var neighbor in neighbors[vertex])
                    {
                        if (arrived[nextPlace][neighbor]) continue;
                        arrived[nextPlace][neighbor] = true;
                        newNext.Add(neighbor);
                    }
                }
                nextVertexes = newNext;
            }
            if (arrived[0][g])
            {
                Console.WriteLine(iteration);
                return;
            }
            if (nextVertexes.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }
        }
    }
}
