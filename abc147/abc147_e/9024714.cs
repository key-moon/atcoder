// detail: https://atcoder.jp/contests/abc147/submissions/9024714
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hw[0];
        int w = hw[1];
        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); }

        var arrived = new bool[h * w];
        var a = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse)).ToArray().Zip(
            Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse)).ToArray(),
            (x, y) => Abs(x - y)
        ).ToArray();
        var offset = 80 * 80;
        var mask = (BigInteger.One << (offset * 2 + 1)) - 1;
        BigInteger[] diffs = Enumerable.Repeat(0, h * w).Select(_ => new BigInteger(0)).ToArray();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        diffs[0] |= BigInteger.One << offset;
        while (queue.Count != 0)
        {
            var last = queue.Dequeue();
            var copied = diffs[last];
            diffs[last] <<= a[last];
            copied >>= a[last];
            diffs[last] |= copied;
            diffs[last] &= mask;
            foreach (var next in graph[last])
            {
                diffs[next] |= diffs[last];
                if (arrived[next]) continue;
                arrived[next] = true;
                queue.Enqueue(next);
            }
        }
        var min = int.MaxValue;
        var lastDiff = diffs.Last();
        for (int i = 0; i <= offset * 2; i++)
        {
            if (((lastDiff >> i) & 1) == 0) continue;
            min = Min(min, Abs(offset - i));
        }
        Console.WriteLine(min);
    }
}
