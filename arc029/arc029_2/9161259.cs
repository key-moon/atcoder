// detail: https://atcoder.jp/contests/arc029/submissions/9161259
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
    const double EPS = 1e-12;
    static int h;
    static int w;
    static double Atan;

    public static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        h = ab[0];
        w = ab[1];
        Atan = Atan2(w, h);
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var H = cd[0];
            var W = cd[1];
            Console.WriteLine(CanFit(W, H) || CanFit(H, W) ? "YES" : "NO");
        }
    }

    public static bool CanFit(double H, int W)
    {
        if (h <= H + EPS && w <= W + EPS) return true;
        var valid = PI / 2 - Atan;
        var invalid = Atan;
        if (W < w * Sin(valid) + h * Cos(valid) + EPS) return false;
        for (int _ = 0; _ < 100; _++)
        {
            var mid = (valid + invalid) / 2;
            if (w * Sin(mid) + h * Cos(mid) <= W + EPS) valid = mid;
            else invalid = mid;
        }
        return h * Sin(valid) + w * Cos(valid) <= H + EPS;
    }
}
