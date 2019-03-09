// detail: https://atcoder.jp/contests/abc121/submissions/4516035
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        var b = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).Zip(b, (x, y) => x * y).Aggregate(nm[2],(x,y) => x + y)).Count(x => x > 0));
    }
}
