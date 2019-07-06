// detail: https://atcoder.jp/contests/bcu30-2019/submissions/6257081
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
        if (a.Length == 0)
        {
            Console.WriteLine(0);
            return;
        }
        int count = 0;
        for (int i = a.Length - 1; i >= 1; i--)
        {
            if (a[i - 1] > a[i]) count++;
        }
        Console.WriteLine(count + 1);
    }
}
