// detail: https://atcoder.jp/contests/diverta2019-2/submissions/5928607
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        var max = a.First();
        var min = a.Last();
        a = a.Skip(1).Take(n - 2).ToArray();
        StringBuilder builder = new StringBuilder();
        foreach (var item in a)
        {
            if (item > 0)
            {
                builder.AppendLine($"{min} {item}");
                min -= item;
            }
            else
            {
                builder.AppendLine($"{max} {item}");
                max -= item;
            }
        }
        builder.AppendLine($"{max} {min}");
        max -= min;
        Console.WriteLine(max);
        Console.Write(builder.ToString());
    }
}
