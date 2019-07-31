// detail: https://atcoder.jp/contests/tkppc4-1/submissions/6626372
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
        var k = Console.ReadLine().Split().Select(int.Parse).Last();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a.Select((Elem, Count) => new { Elem, Count }).Where(x => x.Elem < k).Aggregate(new { Elem = -1, Count = -2 }, (x, y) => (x.Elem < y.Elem ? y : x)).Count + 1);
    }
}
