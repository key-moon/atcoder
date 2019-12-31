// detail: https://atcoder.jp/contests/past201912-open/submissions/9254059
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        var after = Enumerable.Range(1, n).Except(a).FirstOrDefault();
        if (after == 0)
        {
            Console.WriteLine("Correct");
            return;
        }
        var prev = a.GroupBy(x => x).Where(x => x.Count() >= 2).First().Key;
        Console.WriteLine($"{prev} {after}");
    }
}
