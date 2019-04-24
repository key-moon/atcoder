// detail: https://atcoder.jp/contests/utpc2013/submissions/5107655
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
        var holeLess = "[CEFGHIJKLMNSTUVWXYZ]";
        var hole = "[ADOPQR]";
        Console.WriteLine(Regex.IsMatch(Console.ReadLine(), $"^{holeLess}{holeLess}{hole}{holeLess}$") ? "yes" : "no");
    }
}
