// detail: https://atcoder.jp/contests/ddcc2020-qual/submissions/8575793
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
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((prize(xy[0]) + prize(xy[1]) + (xy.All(x => x == 1) ? 4 : 0)) * 100000);
    }
    static int prize(int rank) => rank == 3 ? 1 : rank == 2 ? 2 : rank == 1 ? 3 : 0;
}
