// detail: https://atcoder.jp/contests/abc126/submissions/5461132
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[] c = Console.ReadLine().ToCharArray();
        c[nk[1] - 1] = (char)(c[nk[1] - 1] + 32);
        Console.WriteLine(string.Join("", c));
    }
}
