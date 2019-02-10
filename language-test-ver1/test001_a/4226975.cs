// detail: https://atcoder.jp/contests/language-test-ver1/submissions/4226975
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
        string s = Console.ReadLine();
        var v = Enumerable.Range(1, 4).Select(x => s.Count(y => (y - '0') == x));
        Console.WriteLine($"{v.Max()} {v.Min()}");
    }
}
