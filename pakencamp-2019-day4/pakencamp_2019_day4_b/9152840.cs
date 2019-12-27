// detail: https://atcoder.jp/contests/pakencamp-2019-day4/submissions/9152840
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
        int n = int.Parse(Console.ReadLine());
        long a = 0;
        long b = 1;
        for (int i = 0; i <= n; i++)
        {
            a += b;
            b *= 5 ;
        }
        Console.WriteLine(a);
    }
}
