// detail: https://atcoder.jp/contests/agc008/submissions/8346070
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var minos = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var I = minos[0];
        var O = minos[1];
        var J = minos[3];
        var L = minos[4];
        long res = (I / 2 + J / 2 + L / 2) * 2;
        if (J != 0 && L != 0 && I != 0) res = Max(res, ((I - 1) / 2 + (J - 1) / 2 + (L - 1) / 2) * 2 + 3);
        res += O;
        Console.WriteLine(res);
    }
}
