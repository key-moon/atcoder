// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/4480743
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("", Enumerable.Repeat(1, 1).Concat(Enumerable.Repeat(0, int.Parse(Console.ReadLine()) - 1))));
    }
}
