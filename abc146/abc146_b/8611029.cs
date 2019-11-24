// detail: https://atcoder.jp/contests/abc146/submissions/8611029
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("", Console.ReadLine().Select(x => (char)('A' + ((x - 'A') + n) % 26))));
    }
}
