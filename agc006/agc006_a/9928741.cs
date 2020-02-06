// detail: https://atcoder.jp/contests/agc006/submissions/9928741
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var t = Console.ReadLine();
        for (int i = 0; ; i++)
        {
            var res = s.Substring(0, i) + t;
            if (res.Substring(0, n) == s)
            {
                Console.WriteLine(res.Length);
                return;
            }
        }
    }
}
