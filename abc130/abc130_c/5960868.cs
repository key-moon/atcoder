// detail: https://atcoder.jp/contests/abc130/submissions/5960868
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
        var WHxy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var W = WHxy[0];
        var H = WHxy[1];
        var x = WHxy[2];
        var y = WHxy[3];
        Console.WriteLine($"{W * H / 2.0} {(W == 2 * x && H == 2 * y ? 1 : 0)}");
    }
}
