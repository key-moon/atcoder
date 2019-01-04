// detail: https://atcoder.jp/contests/digitalarts2012/submissions/3927799
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        string[] s = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        string[] regexps = Enumerable.Repeat(0, n).Select(_ => $"^{Console.ReadLine().Replace('*', '.')}$").ToArray();
        Console.WriteLine(string.Join(" ", s.Select(x => regexps.Any(y => Regex.IsMatch(x, y)) ? string.Join("", Enumerable.Repeat('*', x.Length)) : x)));
    }
}
