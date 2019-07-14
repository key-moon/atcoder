// detail: https://atcoder.jp/contests/pakencamp-2018-day3/submissions/6390124
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
        var day = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(day[1] == 12 && day[2] == 25 ? (day[0] - 2018).ToString() : "NOT CHRISTMAS DAY");
    }
}
