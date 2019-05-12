// detail: https://atcoder.jp/contests/agc019/submissions/5377012
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var qhsd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int one = Min(Min(qhsd[0] * 4, qhsd[1] * 2), qhsd[2]);
        int two = qhsd[3];
        long n = int.Parse(Console.ReadLine());
        Console.WriteLine(Min(n / 2 * two + (n % 2) * one, n * one));
    }
}
