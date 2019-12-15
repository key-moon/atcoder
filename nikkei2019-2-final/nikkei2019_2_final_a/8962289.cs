// detail: https://atcoder.jp/contests/nikkei2019-2-final/submissions/8962289
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int i = 1; i < a.Length - 1; i++)
        {
            long countBefore = 0, countAfter = 0;
            for (int j = 0; j < i; j++)
                if (a[j] < a[i]) countBefore++;
            for (int j = i + 1; j < a.Length; j++)
                if (a[i] > a[j]) countAfter++;
            res += countBefore * countAfter;
        }
        Console.WriteLine(res);
    }
}
