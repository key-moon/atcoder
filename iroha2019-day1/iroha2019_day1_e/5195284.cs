// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5195284
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

static class P
{
    static void Main()
    {
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var d = nab[2] == 0 ? new long[0] : Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        long res = nab[0];
        int ptr = 0;
        long lastDate = 0;
        for (int i = 0; i < d.Length; i++)
        {
            res -= (d[i] - lastDate - 1) / nab[1];
            lastDate = d[i];
            res -= 1;
        }
        res -= (nab[0] - lastDate) / nab[1];
        Console.WriteLine(res);
    }
}
