// detail: https://atcoder.jp/contests/diverta2019/submissions/5352788
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
        var rgbn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rgbn[0];
        var g = rgbn[1];
        var b = rgbn[2];
        var n = rgbn[3];
        int res = 0;
        for (int i = 0; i * r <= n; i++)
        {
            for (int j = 0; i * r + j * g <= n; j++)
            {
                if ((n - (i * r + j * g)) % b == 0)
                {
                    //Console.WriteLine($"{i} {j} {(n - (i * r + j * g)) / b}");
                    res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}
