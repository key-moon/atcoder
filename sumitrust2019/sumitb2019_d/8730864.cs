// detail: https://atcoder.jp/contests/sumitrust2019/submissions/8730864
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
        string s = Console.ReadLine();
        int res = 0;
        for (int i = 0; i < 1000; i++)
        {
            int ind = 0;
            var target = $"{i:000}";
            foreach (var c in s)
            {
                if (c == target[ind]) ind++;
                if (ind == 3) break;
            }
            if (ind == 3) res++;
        }
        Console.WriteLine(res);
    }
}
