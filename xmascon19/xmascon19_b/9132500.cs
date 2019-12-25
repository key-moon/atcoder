// detail: https://atcoder.jp/contests/xmascon19/submissions/9132500
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
        Action merryChristmas = () => { Console.WriteLine("Merry Christmas!"); Environment.Exit(0); };
        var nop = Console.ReadLine().Split();
        var n = int.Parse(nop[0]);
        var op = nop[1][0];
        if (op == '=')
        {
            Console.WriteLine(string.Join(" ", Enumerable.Range(0, n)));
            return;
        }
        if (op == '<')
        {
            if (n <= 2) merryChristmas();
            Console.WriteLine($"{string.Join(" ", Enumerable.Range(0, n - 1))} {n + 1}");
            return;
        }
        if (op == '>')
        {
            if (9 <= n)
            {
                int[] first = new int[] { 0, 1, 3 };
                int offset = 7;
                int count = n - 7;
                int[] middle = Enumerable.Range(offset, count).ToArray();
                int endFirst = n + 2;
                int[] end = new int[] { endFirst, endFirst + 2, endFirst + 3, endFirst + 4 };
                var res = first.Concat(middle).Concat(end).ToArray();
                Debug.Assert(Validate(res));
                Console.WriteLine(string.Join(" ", res));
                return;
            }
            if (n == 8)
            {
                Console.WriteLine(string.Join(" ", new int[8] { 0, 2, 3, 4, 7, 11, 12, 14 }));
                return;
            }
            merryChristmas();
        }
    }

    static bool Validate(int[] a)
    {
        if (a.Distinct().Count() != a.Length) return false;
        var minus = a.SelectMany(x => a.Select(y => y - x)).Distinct().Count();
        var plus = a.SelectMany(x => a.Select(y => y + x)).Distinct().Count();
        //Print($"{minus} {plus}");
        return minus < plus;
    }
}
