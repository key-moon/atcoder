// detail: https://atcoder.jp/contests/cpsco2019-s2/submissions/5273287
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
        var mn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = mn[0];
        var n = mn[1];
        for (int i = 0; i < n - 1; i++)
        {
            m -= mn[0] / mn[1];
        }
        Console.WriteLine(m);
    }
}
