// detail: https://atcoder.jp/contests/arc100/submissions/4820893
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select((x, y) => int.Parse(x) - y).ToArray();
        long mid = a.OrderBy(x => x).Skip(n / 2).First();
        Console.WriteLine(a.Sum(x => Abs(x - mid)));
    }
}
