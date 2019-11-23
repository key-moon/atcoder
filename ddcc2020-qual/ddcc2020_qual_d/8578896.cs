// detail: https://atcoder.jp/contests/ddcc2020-qual/submissions/8578896
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int m = int.Parse(Console.ReadLine());
        var dc = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var a = dc.Sum(x => x[0] * x[1]);
        var res = dc.Sum(x => x[1])/*桁数*/;
        res += (a - 1) / 9;
        Console.WriteLine(res - 1);
    }
}
