// detail: https://atcoder.jp/contests/arc046/submissions/8344552
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        if (a == b)
        {
            if (n % (a + 1) != 0) Console.WriteLine("Takahashi");
            else Console.WriteLine("Aoki");
        }
        if (a < b)
        {
            if (n <= a) Console.WriteLine("Takahashi");
            else Console.WriteLine("Aoki");
        }
        if (a > b)
        {
            Console.WriteLine("Takahashi");
        }
    }
}
