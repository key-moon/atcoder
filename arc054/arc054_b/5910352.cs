// detail: https://atcoder.jp/contests/arc054/submissions/5910352
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

static class P
{
    static void Main()
    {
        var p = double.Parse(Console.ReadLine());
        var c = 3 / Log(4);
        var x = Max(0, -c * Log(c / p));
        var t = Pow(2, 2.0 / 3.0);
        //var x = Log((p * Log(t) - 1) / Pow(Log(t) , 2), t);
        Console.WriteLine(x + p / Pow(t, x));
    }
}
