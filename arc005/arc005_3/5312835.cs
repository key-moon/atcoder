// detail: https://atcoder.jp/contests/arc005/submissions/5312835
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();
        int s = 0;
        int g = 0;
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1]; j++)
            {
                if (map[i][j] == 's')
                {
                    s = i * hw[1] + j;
                    map[i][j] = '.';
                }
                if (map[i][j] == 'g')
                {
                    g = i * hw[1] + j;
                    map[i][j] = '.';
                }
            }
        }
        bool[] arrived = new bool[hw[0] * hw[1] * 3];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(s * 3);
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            if (arrived[item]) continue;
            arrived[item] = true;
            var count = item % 3;
            item /= 3;
            var w = item % hw[1];
            item /= hw[1];
            var h = item;

            for (int i = 0; i < 4; i++)
            {
                var newh = h + ((i - 2) % 2);
                var neww = w + ((i - 1) % 2);
                if (0 > newh || newh >= hw[0] || 0 > neww || neww >= hw[1]) continue;
                if (map[newh][neww] == '.') queue.Enqueue((newh * hw[1] + neww) * 3 + count);
                if (map[newh][neww] == '#' && count < 2) queue.Enqueue((newh * hw[1] + neww) * 3 + count + 1);
            }
        }
        Console.WriteLine(arrived.Skip(g * 3).Take(3).Any(x => x) ? "YES" : "NO");
    }
}
