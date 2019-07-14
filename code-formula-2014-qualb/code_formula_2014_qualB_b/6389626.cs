// detail: https://atcoder.jp/contests/code-formula-2014-qualb/submissions/6389626
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine($"{s.Where((_, ind) => ind % 2 == s.Length % 2).Sum(x => x - '0')} {s.Where((_, ind) => ind % 2 != s.Length % 2).Sum(x => x - '0')}");

    }
}
