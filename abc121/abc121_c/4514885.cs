// detail: https://atcoder.jp/contests/abc121/submissions/4514885
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();

        var hoge =  Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToList()).OrderBy(x => x[0]).ToList();
        long count = nm[1];
        long res = 0;
        foreach (var item in hoge)
        {
            res += Min(count, item[1]) * item[0];
            count -= Min(count, item[1]);
        }
        Console.WriteLine(res);
    }
}
