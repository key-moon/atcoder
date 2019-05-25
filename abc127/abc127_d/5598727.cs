// detail: https://atcoder.jp/contests/abc127/submissions/5598727
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        var queries = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderByDescending(x => x[1]).ToArray();

        var aptr = 0;
        foreach (var query in queries)
        {
            var count = query[0];
            var num = query[1];
            for (int i = 0; i < count && aptr < a.Length && a[aptr] < num; i++, aptr++) a[aptr] = num;
        }
        Console.WriteLine(a.Sum());
    }
}
