// detail: https://atcoder.jp/contests/code-formula-2014-final/submissions/5115690
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
using Debug = System.Diagnostics.Debug;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(ab[0] * ab[1]);
    }
}
