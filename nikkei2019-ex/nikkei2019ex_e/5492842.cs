// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/5492842
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
        long n = 1789997546303;
        int p = int.Parse(Console.ReadLine());
        for (int i = 1000; i >= 0; i--)
        {
            if (i == p) break;
            n = n % 2 == 0 ? n / 2 : n * 3 + 1;
        }
        Console.WriteLine(n);
    }
}
