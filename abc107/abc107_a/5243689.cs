// detail: https://atcoder.jp/contests/abc107/submissions/5243689
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var ni = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ni[0] - ni[1] + 1);
    }
}
