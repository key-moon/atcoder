// detail: https://atcoder.jp/contests/abc083/submissions/3180710
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        long[] xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long x = xy[0];
        long y = xy[1];
        int res = 0;
        while (x <= y)
        {
            x *= 2;
            res++;
        }
        Console.WriteLine(res);
    }
}
