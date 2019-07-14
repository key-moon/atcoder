// detail: https://atcoder.jp/contests/code-formula-2014-quala/submissions/6389493
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        Console.WriteLine(a == Pow(Round(Pow(a, 1.0 / 3)), 3) ? "YES" : "NO");
    }
}
