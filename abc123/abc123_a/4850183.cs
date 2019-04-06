// detail: https://atcoder.jp/contests/abc123/submissions/4850183
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
        var a = Enumerable.Repeat(0, 5).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        var k = int.Parse(Console.ReadLine());
        Console.WriteLine(a[4] - a[0] <= k ? "Yay!" : ":(");
    }
}
