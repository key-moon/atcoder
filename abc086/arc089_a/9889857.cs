// detail: https://atcoder.jp/contests/abc086/submissions/9889857
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

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var lastX = 0;
        var lastY = 0;
        var lastT = 0;
        for (int i = 0; i < n; i++)
        {
            var txy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int t = txy[0], x = txy[1], y = txy[2];
            var dt = t - lastT;
            var dx = Abs(x - lastX);
            var dy = Abs(y - lastY);
            if (dt < dx + dy || ((dt ^ (dx + dy)) & 1) == 1)
            {
                Console.WriteLine("No");
                return;
            }
            lastX = x;
            lastY = y;
            lastT = t;
        }
        Console.WriteLine("Yes");
    }
}
