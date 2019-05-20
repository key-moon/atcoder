// detail: https://atcoder.jp/contests/agc011/submissions/5492522
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        long accum = 0;
        int res = 0;
        for (int i = 0; i < a.Length - 1; i++)
        {
            accum += a[i];
            if (a[i + 1] <= accum * 2) res++;
            else res = 0;
        }
        Console.WriteLine(res + 1);
    }
}
