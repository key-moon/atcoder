// detail: https://atcoder.jp/contests/abc109/submissions/5174016
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
        var a = Console.ReadLine().Split().Select(int.Parse).Skip(1).Concat(Console.ReadLine().Split().Select(int.Parse)).OrderBy(x => x).ToArray();
        Console.WriteLine(a.Zip(a.Skip(1), (x, y) => y - x).Aggregate(GCD));
    }

    static int GCD(int a, int b)
    {
        while (true)
        {
            if (a > b)
            {
                if (b == 0) return a;
                a %= b;
            }
            else
            {
                if (a == 0) return b;
                b %= a;
            }
        }
    }
}
