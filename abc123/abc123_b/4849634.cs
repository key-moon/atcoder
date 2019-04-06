// detail: https://atcoder.jp/contests/abc123/submissions/4849634
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int time = 0;

        foreach (var a in Enumerable.Repeat(0, 5).Select(_ => int.Parse(Console.ReadLine())).OrderByDescending(x => (x + 9) % 10))
        {
            time = (time / 10 + (time % 10 == 0 ? 0 : 1)) * 10;
            time += a;
        }
        Console.WriteLine(time);

    }
}
