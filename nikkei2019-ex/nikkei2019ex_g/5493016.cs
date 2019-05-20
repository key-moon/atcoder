// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/5493016
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
        var a = Console.ReadLine().GroupBy(x => x).Select(x => x.Count()).ToArray();
        var odd = a.Sum(x => x & 1);
        long kaibunLength = a.Sum(x => (x >> 1) << 1);
        if (odd != 0)
        {
            kaibunLength++;
            odd--;
        }
        Console.WriteLine(odd + kaibunLength * kaibunLength);
    }
}
