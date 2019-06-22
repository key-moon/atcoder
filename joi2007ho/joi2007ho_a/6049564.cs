// detail: https://atcoder.jp/contests/joi2007ho/submissions/6049564
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
        var nk = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        long sum = 0;
        Queue<long> queue = new Queue<long>(k + 1);
        for (int i = 0; i < k; i++)
        {
            var next = long.Parse(Console.ReadLine().Trim());
            queue.Enqueue(next);
            sum += next;
        }
        long max = sum;
        for (int i = k; i < n; i++)
        {
            var next = long.Parse(Console.ReadLine().Trim());
            queue.Enqueue(next);
            sum += next;
            sum -= queue.Dequeue();
            max = Max(max, sum);
        }
        Console.WriteLine(max);
    }
}
