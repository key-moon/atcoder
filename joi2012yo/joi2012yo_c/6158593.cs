// detail: https://atcoder.jp/contests/joi2012yo/submissions/6158593
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
        int n = int.Parse(Console.ReadLine());
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int c = int.Parse(Console.ReadLine());
        var toppings = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).OrderByDescending(x => x).ToArray();
        Console.WriteLine((int)Floor(Enumerable.Range(0, toppings.Length + 1).Select(x => (c + (double)toppings.Take(x).Sum()) / (ab[0] + ab[1] * x)).Max()));
    }
}
