// detail: https://atcoder.jp/contests/abc149/submissions/9208536
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
        var abk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abk[0];
        var b = abk[1];
        var k = abk[2];
        var op1 = Min(a, k);
        a -= op1;
        k -= op1;
        var op2 = Min(b, k);
        b -= op2;
        k -= op2;
        Console.WriteLine($"{a} {b}");
    }
}
