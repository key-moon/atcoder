// detail: https://atcoder.jp/contests/abc117/submissions/4153441
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] l = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        Console.WriteLine(l.Last() < l.Take(n - 1).Sum() ? "Yes" : "No");
    }
}
