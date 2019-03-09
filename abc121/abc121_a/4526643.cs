// detail: https://atcoder.jp/contests/abc121/submissions/4526643
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
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var HW = Console.ReadLine().Split().Select(long.Parse).ToList();
        var hw = Console.ReadLine().Split().Select(long.Parse).ToList();
        Console.WriteLine(HW[0] * HW[1] - HW[0] * hw[1] - hw[0] * HW[1] + hw[0] * hw[1]);
    }
}
