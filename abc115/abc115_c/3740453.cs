// detail: https://atcoder.jp/contests/abc115/submissions/3740453
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] h = Enumerable.Repeat(0, nk[0]).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();

        int min = int.MaxValue;
        for (int i = 0; i <= nk[0] - nk[1]; i++)
        {
            min = Min(min, Abs(h[i] - h[i + nk[1] - 1]));
        }
        Console.WriteLine(min);
    }
}
