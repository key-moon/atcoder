// detail: https://atcoder.jp/contests/bcu30-2019-qual/submissions/6625534
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
        var p = Console.ReadLine().Split().Select(int.Parse).Last();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).TakeWhile(x => (p -= x) >= 0).Count());
    }
}
