// detail: https://atcoder.jp/contests/jag2018summer-day2/submissions/4572485
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToList();
        long res = abc[2];
        while (res % 17 != abc[0] || res % 107 != abc[1]) res += 1000000007;
        Console.WriteLine(res);
    }
}
