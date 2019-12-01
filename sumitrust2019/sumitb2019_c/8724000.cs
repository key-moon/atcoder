// detail: https://atcoder.jp/contests/sumitrust2019/submissions/8724000
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
        for (int i = 0; i < 1000; i++)
        {
            var remain = n - i * 100;
            if (remain < 0) continue;
            if (i * 5 < remain) continue;
            Console.WriteLine(1);
            return;
        }
        Console.WriteLine(0);
    }
}
