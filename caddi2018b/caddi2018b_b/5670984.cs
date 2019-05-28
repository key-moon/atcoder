// detail: https://atcoder.jp/contests/caddi2018b/submissions/5670984
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
        var nhw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Enumerable.Repeat(0, nhw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Count(x => nhw[1] <= x[0] && nhw[2] <= x[1]));
    }
}
