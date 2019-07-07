// detail: https://atcoder.jp/contests/abc133/submissions/6265465
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Min(nab[2], nab[0] * nab[1]));
    }
}
