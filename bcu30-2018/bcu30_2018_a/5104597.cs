// detail: https://atcoder.jp/contests/bcu30-2018/submissions/5104597
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var aMul = Console.ReadLine().Split().Select(int.Parse).Aggregate(1L, (x, y) => x * y);
        int m = int.Parse(Console.ReadLine());
        var bMul = Console.ReadLine().Split().Select(int.Parse).Aggregate(1L, (x, y) => x * y);
        Console.WriteLine(aMul == bMul ? "Yes" : "No");
    }
}
