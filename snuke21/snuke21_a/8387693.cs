// detail: https://atcoder.jp/contests/snuke21/submissions/8387693
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;   
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        for (long i = (int)Ceiling(Sqrt(n * 2)); n <= i * (i + 1) / 2; i--)
        {
            if (i * (i + 1) / 2 == n)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}
