// detail: https://atcoder.jp/contests/abc151/submissions/9470688
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
        var nkm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nkm[0];
        var k = nkm[1];
        var m = nkm[2];
        var sum = Console.ReadLine().Split().Select(int.Parse).Sum();
        for (int i = 0; i <= k; i++)
        {
            if (m * n <= sum + i)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}
