// detail: https://atcoder.jp/contests/abc124/submissions/4939191
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var h = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int curMax = 0;
        int res = 0;
        foreach (var item in h)
        {
            if (curMax <= item) res++;
            curMax = Max(item, curMax);
        }
        Console.WriteLine(res);
    }
}
