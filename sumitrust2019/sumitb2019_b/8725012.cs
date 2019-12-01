// detail: https://atcoder.jp/contests/sumitrust2019/submissions/8725012
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
        for (int i = 0; i <= n; i++)
        {
            if (n == i * 108 / 100)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(":(");
    }
}
