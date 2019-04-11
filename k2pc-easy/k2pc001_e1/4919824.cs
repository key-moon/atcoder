// detail: https://atcoder.jp/contests/k2pc-easy/submissions/4919824
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine($"{Max(0, n - abc[0])} {Max(0, n * 2 - abc[1])} {Max(0, n * 3 - abc[2])}");
    }
}
