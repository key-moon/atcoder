// detail: https://atcoder.jp/contests/abc071/submissions/6300619
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var v = a.GroupBy(x => x).Where(x => x.Count() >= 2).OrderByDescending(x => x.Key).ToArray();
        if (v.Length < 2)
        {
            Console.WriteLine(0);
            return;
        }
        if (v[0].Count() < 4)
        {
            Console.WriteLine(v[0].Key * v[1].Key);
            return;
        }
        {
            Console.WriteLine(v[0].Key * v[0].Key);
            return;
        }
    }
}
