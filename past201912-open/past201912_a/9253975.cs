// detail: https://atcoder.jp/contests/past201912-open/submissions/9253975
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
        int a = 0;
        if (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("error");
            return;
        }
        Console.WriteLine(a * 2);
    }
}
