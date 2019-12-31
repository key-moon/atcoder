// detail: https://atcoder.jp/contests/past201912-open/submissions/9254005
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
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var prev = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            var a = int.Parse(Console.ReadLine());
            var diff =a - prev;
            if (diff < 0)
                Console.WriteLine($"down {-diff}");
            if (diff > 0)
                Console.WriteLine($"up {diff}");
            if (diff == 0)
                Console.WriteLine($"stay");
            prev = a;
        }
    }
}
