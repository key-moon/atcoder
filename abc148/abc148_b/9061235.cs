// detail: https://atcoder.jp/contests/abc148/submissions/9061235
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n= int.Parse(Console.ReadLine());
        var s = Console.ReadLine().Split();
        Console.WriteLine(string.Join("", s[0].Zip(s[1], (x, y) => $"{x}{y}")));
    }
}
