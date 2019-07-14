// detail: https://atcoder.jp/contests/code-thanks-festival-2018/submissions/6389805
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Action exit = () => { Console.WriteLine("No"); Environment.Exit(0); };
        var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = (xy[0] - (xy.Sum() / 4));
        if (a < 0) exit();
        
        Console.WriteLine(a % 2 == 0 && 0 <= a && a / 2 <= xy.Sum() / 4 && xy.Sum() % 4 == 0 ? "Yes" : "No");
    }
}
