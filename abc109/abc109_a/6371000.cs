// detail: https://atcoder.jp/contests/abc109/submissions/6371000
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ab.Any(x => x % 2 == 0) ? "No" : "Yes");
    }
}
