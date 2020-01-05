// detail: https://atcoder.jp/contests/arc097/submissions/9322481
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

public static class P
{
    public static void Main()
    {
        var s = Console.ReadLine();
        var k = int.Parse(Console.ReadLine());
        List<string> res = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            var max = Min(k, s.Length - i);
            for (int j = 1; j <= max; j++)
            {
                res.Add(s.Substring(i, j));
            }
        }
        Console.WriteLine(res.Distinct().OrderBy(x => x).Take(k).Last());
    }
}
