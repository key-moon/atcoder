// detail: https://atcoder.jp/contests/cpsco2019-s1/submissions/5668252
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
        Console.WriteLine(Console.ReadLine().GroupBy(x => x).Select(x => x.Count()).Distinct().Count() == 1 ? "Yes" : "No");
    }
}
