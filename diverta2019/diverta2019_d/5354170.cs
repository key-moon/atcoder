// detail: https://atcoder.jp/contests/diverta2019/submissions/5354170
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int sqrt = (int)Ceiling(Sqrt(n));
        long res = 0;
        for (int i = 1; i <= sqrt; i++)
        {
            if (n % i != 0) continue;
            long div = n / i;
            if (div - 1 <= i) continue;
            res += (div - 1);
        }
        Console.WriteLine(res);
    }
}
