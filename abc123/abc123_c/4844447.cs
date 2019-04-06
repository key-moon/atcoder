// detail: https://atcoder.jp/contests/abc123/submissions/4844447
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long d = long.Parse(Console.ReadLine());
        long e = long.Parse(Console.ReadLine());
        var hoge = Min(Min(Min(Min(a, b), c), d), e);
        Console.WriteLine(n / hoge + (n % hoge == 0 ? 0 : 1) + 4);
    }
}
