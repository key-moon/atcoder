// detail: https://atcoder.jp/contests/abc150/submissions/9394428
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
        var kx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = kx[0];
        var x = kx[1];
        Console.WriteLine(k * 500 >= x ?  "Yes" : "No");
    }
}
