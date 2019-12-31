// detail: https://atcoder.jp/contests/past201912-open/submissions/9254380
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
        Console.WriteLine(string.Join("", Regex.Matches(Console.ReadLine(), "[A-Z][a-z]*[A-Z]").Cast<Match>().Select(x => x.Value).OrderBy(x => x.ToLower())));
    }
}
