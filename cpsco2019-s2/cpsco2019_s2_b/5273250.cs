// detail: https://atcoder.jp/contests/cpsco2019-s2/submissions/5273250
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int res = 0;
        foreach (var item in Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split()).OrderBy(x => x[0][0] == '+' ? 0 : x[1][0] == '+' ? 1 : 2))
        {
            switch (item[0])
            {
                case "+":
                    res += int.Parse(item[1]);
                    break;
                case "*":
                    if (item[1] == "0") continue;
                    res *= int.Parse(item[1]);
                    break;
            }
        }
        Console.WriteLine(res);
    }
}
