// detail: https://atcoder.jp/contests/abc144/submissions/8153242
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        var sqrt = (int)Ceiling(Sqrt(n));
        long min = long.MaxValue;
        for (int i = 1; i <= sqrt; i++)
        {
            if (n % i == 0) min = Min(min, i + n / i - 2);
        }
        Console.WriteLine(  min);
    }
}
