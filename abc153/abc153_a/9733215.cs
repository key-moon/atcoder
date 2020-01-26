// detail: https://atcoder.jp/contests/abc153/submissions/9733215
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
        var ha = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((ha[0] + ha[1] - 1) / ha[1]);
    }
}
