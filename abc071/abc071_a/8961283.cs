// detail: https://atcoder.jp/contests/abc071/submissions/8961283
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
        var xab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Abs(xab[0] - xab[1]) < Abs(xab[0] - xab[2]) ? "A" : "B");
    }
}
