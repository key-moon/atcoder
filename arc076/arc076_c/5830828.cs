// detail: https://atcoder.jp/contests/arc076/submissions/5830828
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
    static int r;
    static int c;
    static void Main()
    {
        r = Read();
        c = Read();
        var n = Read();

        List<Tuple<int, int>> edgeIndices = new List<Tuple<int, int>>();
        for (int i = 0; i < n; i++)
        {
            var x1 = Read();
            var y1 = Read();
            var x2 = Read();
            var y2 = Read();
            if (!IsEdge(x1, y1) || !IsEdge(x2, y2)) continue;
            var edgeInd1 = ToEdgeIndex(x1, y1);
            var edgeInd2 = ToEdgeIndex(x2, y2);
            edgeIndices.Add(new Tuple<int, int>(Min(edgeInd1, edgeInd2), Max(edgeInd1, edgeInd2)));
        }
        Stack<int> stack = new Stack<int>();
        foreach (var item in edgeIndices.OrderBy(x => x.Item1))
        {
            while (stack.Count > 0 && stack.Peek() < item.Item1) stack.Pop();

            if (stack.Count > 0 && stack.Peek() < item.Item2)
            {
                Console.WriteLine("NO");
                return;
            }
            stack.Push(item.Item2);
        }
        Console.WriteLine("YES");
    }

    static bool IsEdge(int x, int y) => (x == 0 || x == r) || (y == 0 || y == c);

    static int ToEdgeIndex(int x, int y) => ((x == 0 && y != 0) || y == c) ? (c + r) * 2 - (x + y) : x + y;
     
    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
