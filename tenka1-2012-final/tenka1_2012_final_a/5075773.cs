// detail: https://atcoder.jp/contests/tenka1-2012-final/submissions/5075773
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        long[] fib = new long[61];
        fib[1] = 1;
        for (int i = 2; i < 61; i++) fib[i] = fib[i - 1] + fib[i - 2];
        long n = long.Parse(Console.ReadLine());
        int res = 0;
        for (int i = fib.Length - 1; i >= 1; i--)
        {
            if (n >= fib[i])
            {
                n -= fib[i];
                res++;
            }
        }
        Console.WriteLine(res);
    }
}
