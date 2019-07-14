// detail: https://atcoder.jp/contests/code-festival-2014-quala/submissions/6389652
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
        var a = Console.ReadLine();
        Console.WriteLine(a[(int.Parse(Console.ReadLine()) - 1) % a.Length]);

    }
}
