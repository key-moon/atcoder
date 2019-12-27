// detail: https://atcoder.jp/contests/pakencamp-2019-day4/submissions/9153262
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
        Action abort = () => { Console.WriteLine(-1); Environment.Exit(0); };
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        var k = -1;
        for (int i = 0; i <= n; i++)
        {
            if (x < ((i + 2) * (i + 1)) / 2)
            {
                k = i;
                break;
            }
        }
        Console.WriteLine(k);
        List<int> res = new List<int>();
        for (int i = 0; i < k; i++)
        {
            res.Add(1);
        }
        var diff = x - k * (k + 1) / 2;
        if (0 < diff) res.Add(k - diff + 1);
        while (res.Count < n)
        {
            res.Add(1333333);
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
