// detail: https://atcoder.jp/contests/abc134/submissions/6455550
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = new int[n];
        for (int i = a.Length; i >= 1; i--)
        {
            int sum = 0;
            for (int j = i; j <= n; j += i)
            {
                sum += res[j - 1];
            }
            res[i - 1] = sum % 2 != a[i - 1] ? 1 : 0;
        }
        var balls = res.Select((elem, count) => new { elem, count }).Where(x => x.elem == 1).Select(x => x.count + 1).ToArray();
        Console.WriteLine(balls.Length);
        if (balls.Length != 0) Console.WriteLine(string.Join("
", balls));
    }
}
