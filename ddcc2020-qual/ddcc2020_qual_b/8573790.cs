// detail: https://atcoder.jp/contests/ddcc2020-qual/submissions/8573790
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        var a = Console.ReadLine().Split().Select(x => long.Parse(x) * 2).ToArray();
        var half = a.Sum() / 2;
        long sum = 0;
        var halfa = a.TakeWhile(x => (sum += x) <= half).ToArray();
        var halfb = a.Skip(halfa.Length).ToArray();

        var fir = Abs(halfb.Sum() - halfa.Sum());
        var sec = Abs(a.Take(halfa.Length + 1).Sum() - a.Skip(halfa.Length + 1).Sum());

        Console.WriteLine(Min(fir, sec) / 2);
    }
}
