// detail: https://atcoder.jp/contests/abc125/submissions/5144718
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
        var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(v.Zip(c,(x,y) => x - y).Where(x => x >= 0).Sum());
    }
}
