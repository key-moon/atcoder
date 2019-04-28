// detail: https://atcoder.jp/contests/abc113/submissions/5173011
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(string.Join("
", Enumerable.Range(0, nm[1]).Select(x => new Tuple<int[], int>(Console.ReadLine().Split().Select(int.Parse).ToArray(), x)).GroupBy(x => x.Item1[0]).SelectMany(x => x.OrderBy(y => y.Item1[1]).Select((y, z) => new Tuple<string, int>($"{y.Item1[0].ToString().PadLeft(6, '0')}{(z + 1).ToString().PadLeft(6, '0')}", y.Item2))).OrderBy(x => x.Item2).Select(x => x.Item1)));
    }
}
