// detail: https://atcoder.jp/contests/abc029/submissions/8959662
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
        List<string> res = new List<string>() { "" };
        for (int i = 0; i < n; i++)
        {
            List<string> newRes = new List<string>();
            newRes.AddRange(res.Select(x => "a" + x));
            newRes.AddRange(res.Select(x => "b" + x));
            newRes.AddRange(res.Select(x => "c" + x));
            res = newRes;
        }

        Console.WriteLine(string.Join("
", res));
    }
}
