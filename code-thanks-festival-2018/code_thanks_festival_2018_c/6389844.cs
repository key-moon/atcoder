// detail: https://atcoder.jp/contests/code-thanks-festival-2018/submissions/6389844
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
        var n = int.Parse(Console.ReadLine());

        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        Console.WriteLine(a.Zip(a.Skip(1), (x, y) => y - x).Select((x, y) => x * (y + 1) * (n - y - 1)).Sum());
    }
}
