// detail: https://atcoder.jp/contests/cpsco2019-s3/submissions/5277142
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
        string s = Console.ReadLine();
        Console.WriteLine(Regex.IsMatch(s, @"^((R|RG)*RGB(GB|B)*)(G?(R|RG)*RGB(GB|B)*)*$") ? "Yes" : "No");
    }
}
