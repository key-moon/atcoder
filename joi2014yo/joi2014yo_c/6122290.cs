// detail: https://atcoder.jp/contests/joi2014yo/submissions/6122290
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


static class P
{
    static void Main()
    {
        var n = Console.ReadLine().Split().Select(int.Parse).Last();
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int lastX = xy[0];
        int lastY = xy[1];
        var res = 0;
        for (int i = 1; i < n; i++)
        {
            xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x = xy[0];
            var y = xy[1];
            res += Abs(lastX - x) + Abs(lastY - y);
            if ((x < lastX) == (y < lastY)) res -= Min(Abs(lastX - x), Abs(lastY - y));
            lastX = x;
            lastY = y;
        }
        Console.WriteLine(res);
    }
}
