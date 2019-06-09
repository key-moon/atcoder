// detail: https://atcoder.jp/contests/abc129/submissions/5835297
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
        var w = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int min = int.MaxValue;
        for (int i = 1; i < w.Length; i++)
        {
            min = Min(min, Abs(w.Skip(i).Sum() - w.Take(i).Sum()));
        }
        Console.WriteLine(min);
    }
}
