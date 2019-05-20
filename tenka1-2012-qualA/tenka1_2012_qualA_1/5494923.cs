// detail: https://atcoder.jp/contests/tenka1-2012-qualA/submissions/5494923
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        ulong[] fib = new ulong[int.Parse(Console.ReadLine()) + 2];
        fib[1] = 1;
        for (int i = 2; i < fib.Length; i++) fib[i] = fib[i - 2] + fib[i - 1];
        Console.WriteLine(fib.Last());
    }
}
