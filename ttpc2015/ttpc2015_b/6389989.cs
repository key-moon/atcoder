// detail: https://atcoder.jp/contests/ttpc2015/submissions/6389989
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nbc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res = 0;
        foreach (var item in a.Reverse())
        {
            var r = Min(nbc[1], nbc[2]);
            res += r * item;
            nbc[2] -= r;
        }
        Console.WriteLine(res);
    }
}
