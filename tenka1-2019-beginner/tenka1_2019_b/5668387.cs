// detail: https://atcoder.jp/contests/tenka1-2019-beginner/submissions/5668387
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
        var n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var k = int.Parse(Console.ReadLine());
        Console.WriteLine(Regex.Replace(s, $"[^{s[k - 1]}]", "*"));
    }
}
