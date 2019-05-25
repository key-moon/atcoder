// detail: https://atcoder.jp/contests/abc127/submissions/5585874
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
        var rdx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long x = rdx[2];
        for (int i = 0; i < 10; i++)
        {
            x = x * rdx[0] - rdx[1];
            Console.WriteLine(x);
        }
    }
}
