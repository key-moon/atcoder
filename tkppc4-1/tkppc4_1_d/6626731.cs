// detail: https://atcoder.jp/contests/tkppc4-1/submissions/6626731
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var diff = a.Zip(a.Skip(1), (x, y) => x - y).Where(x => x != 0).ToArray();
        Console.WriteLine(diff.Length == 0 ? 0 : diff.Zip(diff.Skip(1), (x, y) => (x < 0) ^ (y < 0)).Count(x => x) + 2);
    }
}
