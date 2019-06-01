// detail: https://atcoder.jp/contests/m-solutions2019/submissions/5725198
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
        Console.WriteLine(Console.ReadLine().PadLeft(15, 'o').Count(x => x == 'o') >= 8 ? "YES" : "NO");
    }
}
