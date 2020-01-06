// detail: https://atcoder.jp/contests/arc045/submissions/9331758
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
        var X = NextInt;

        List<Tuple<int, int>>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<Tuple<int, int>>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var s = NextInt - 1;
            var t = NextInt - 1;
            var c = NextInt;
            graph[s].Add(new Tuple<int, int>(t, c));
            graph[t].Add(new Tuple<int, int>(s, c));
        }
        Tuple<int, int>[] parentsEdge = new Tuple<int, int>[n];
        bool[] arrived = new bool[n];
        Dictionary<int, int> counts = new Dictionary<int, int>();
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        parentsEdge[0] = null;
        stack.Push(new Tuple<int, int>(0, 0));
        long res = 0;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            var ind = elem.Item1;
            var xor = elem.Item2;
            if (!arrived[ind])
            {
                arrived[ind] = true;
                int value;
                res += counts.TryGetValue(xor ^ X, out value) ? value : 0;
                if (!counts.ContainsKey(xor)) counts.Add(xor, 0);
                counts[xor]++;
            }
            foreach (var adj in graph[ind])
            {
                if (arrived[adj.Item1]) continue;
                parentsEdge[adj.Item1] = new Tuple<int, int>(ind, adj.Item2);
                stack.Push(new Tuple<int, int>(adj.Item1, xor ^ adj.Item2));
            }
        }
        Console.WriteLine(res);
    }
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
