// detail: https://atcoder.jp/contests/abc148/submissions/9066392
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        if (n % 2 == 1)
        {
            Console.WriteLine(0);
            return;
        }
        ulong res = 0;
        for (ulong i = 10; i <= 1000000000000000000; i *= 5)
        {
            res += n / i;
        }
        Console.WriteLine(res);
    }
}
