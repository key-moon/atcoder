// detail: https://atcoder.jp/contests/abc156/submissions/10263875
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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
        var nk =  Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        while (nk[0] != 0)

        {
            nk[0] /= nk[1];
            res++;
        }
        Console.WriteLine(res);
    }
}
