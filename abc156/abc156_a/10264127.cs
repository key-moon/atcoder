// detail: https://atcoder.jp/contests/abc156/submissions/10264127
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
        var nr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(nr[1] + Max(0, 10 - nr[0]) * 100);
    }
}
