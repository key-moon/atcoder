// detail: https://atcoder.jp/contests/abc029/submissions/8959737
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
        var n = Console.ReadLine();
        long res = 0;
        for (int i = 0; i < n.Length; i++)
        {
            var dig = n.Length - i - 1;
            if (n[i] == '0') res += 0;
            else if (n[i] == '1') res += long.Parse("0" + n.Substring(i + 1)) + 1;
            else res += (int)Pow(10, dig);
            //xx_0000
            res += (n[i] - '0') * ((int)Pow(10, dig - 1) * dig);
        }
        Console.WriteLine(res);
    }
}
