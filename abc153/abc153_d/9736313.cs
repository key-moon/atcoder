// detail: https://atcoder.jp/contests/abc153/submissions/9736313
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var h = long.Parse(Console.ReadLine());
        long l = 1;
        while (l <= h) l <<= 1;
        Console.WriteLine(l - 1);
    }
    
}
