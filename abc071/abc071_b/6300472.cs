// detail: https://atcoder.jp/contests/abc071/submissions/6300472
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
        var v = Enumerable.Range((int)'a', 26).Except(Console.ReadLine().Select(x => (int)x)).FirstOrDefault();
        Console.WriteLine(v == 0 ? "None" : ((char)v).ToString());
    }
}
