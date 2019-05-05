// detail: https://atcoder.jp/contests/cpsco2019-s3/submissions/5276778
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).TakeWhile(x => ((nm[1] -= x) + x) > 0).Count());
    }
}
