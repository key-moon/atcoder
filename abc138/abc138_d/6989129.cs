// detail: https://atcoder.jp/contests/abc138/submissions/6989129
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = NextInt;
        var q = NextInt;
        var neighbors = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var a = NextInt - 1;
            var b = NextInt - 1;
            neighbors[a].Add(b);
            neighbors[b].Add(a);
        }
        long[] val = new long[n];
        for (int i = 0; i < q; i++)
        {
            val[NextInt - 1] += NextInt;
        }
        bool[] arrived = new bool[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        arrived[0] = true;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var neighbor in neighbors[elem])
            {
                if (arrived[neighbor]) continue;
                arrived[neighbor] = true;
                val[neighbor] += val[elem];
                stack.Push(neighbor);
            }
        }
        Console.WriteLine(string.Join(" ", val));
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
