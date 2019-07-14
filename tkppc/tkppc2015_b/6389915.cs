// detail: https://atcoder.jp/contests/tkppc/submissions/6389915
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
        Console.WriteLine(Enumerable.Range(1, int.Parse(Console.ReadLine())).Select((x, y) => new Tuple<int, int>(int.Parse(Console.ReadLine()), x)).OrderByDescending(x => x.Item1).ThenBy(x => x.Item2).First().Item2);
    }
}
