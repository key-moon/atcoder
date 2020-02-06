// detail: https://atcoder.jp/contests/abc051/submissions/9928809
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
        var ks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int x = 0; x <= ks[0]; x++)
        {
            for (int y = 0; y <= ks[0]; y++)
            {
                var z = ks[1] - x - y;
                if (0 <= z && z <= ks[0]) res++;
            }
        }
        Console.WriteLine(res);
    }
}
