// detail: https://atcoder.jp/contests/abc087/submissions/3180697
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int res = 0;
        for (int i = 0; i <= a; i++)
        {
            for (int j = 0; j <= b; j++)
            {
                for (int k = 0; k <= c; k++)
                {
                    if (i * 500 + j * 100 + k * 50 == x) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}
