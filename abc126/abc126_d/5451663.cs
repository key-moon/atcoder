// detail: https://atcoder.jp/contests/abc126/submissions/5451663
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
        int n = int.Parse(Console.ReadLine());
        var neighbours = Enumerable.Repeat(0, n).Select(x => new List<Tuple<int, int>>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var uvw = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var u = uvw[0] - 1;
            var v = uvw[1] - 1;
            var w = uvw[2];
            neighbours[u].Add(new Tuple<int, int>(v, w));
            neighbours[v].Add(new Tuple<int, int>(u, w));
        }
        int[] res = Enumerable.Repeat(-1, n).ToArray();
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        res[0] = 0;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var neighbour in neighbours[elem])
            {
                if (res[neighbour.Item1] != -1) continue;
                res[neighbour.Item1] = res[elem] ^ (neighbour.Item2 & 1);
                stack.Push(neighbour.Item1);
            }
        }
        Console.WriteLine(string.Join("
", res));
    }

}
