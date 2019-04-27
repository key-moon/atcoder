// detail: https://atcoder.jp/contests/abc125/submissions/5144767
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


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        long current = a.Sum();
        long max = current;
        for (int i = 1; i < a.Length; i += 2)
        {
            a[i - 1] *= -1;
            a[i] *= -1;
            current += (a[i - 1] + a[i]) * 2;
            max = Max(max, current);
        }
        Console.WriteLine(max);
    }
}
