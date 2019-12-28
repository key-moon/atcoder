// detail: https://atcoder.jp/contests/agc041/submissions/9189852
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
        int n = int.Parse(Console.ReadLine());
        if (n == 2)
        {
            Console.WriteLine(-1);
            return;
        }
        if (n == 3)
        {
            Console.WriteLine(
@"
eei
i.i
iee
");
            return;
        }
        if (n == 4)
        {
            Console.WriteLine(
@"
aacd
bbcd
cdaa
cdbb
");
            return;
        }
        if (n == 5)
        {
            Console.WriteLine(
@"
a.bcc
a.bd.
.eedf
ggi.f
hhijj
");
            return;
        }
        else
        {
            var res = Enumerable.Range(0, n).Select(_ => Enumerable.Repeat('.', n).ToArray()).ToArray();
            res[0][0] = 'a';
            res[0][1] = 'a';
            res[0][n - 1] = 'a';
            res[1][n - 1] = 'a';
            res[n - 1][n - 1] = 'a';
            res[n - 1][n - 2] = 'a';
            res[n - 1][0] = 'a';
            res[n - 2][0] = 'a';

            res[1][0] = 'b';
            res[2][0] = 'b';
            res[n - 1][1] = 'b';
            res[n - 1][2] = 'b';
            res[n - 2][n - 1] = 'b';
            res[n - 3][n - 1] = 'b';
            res[0][n - 2] = 'b';
            res[0][n - 3] = 'b';
            char c1 = 'c';
            char c2 = 'd';
            for (int i = 1; i < n - 3; i++)
            {
                    res[i][i + 1] = c1;
                    res[i][i + 2] = c1;
                    res[i + 1][i] = c2;
                    res[i + 2][i] = c2;
                    var tmp = c1;
                    c1 = c2;
                    c2 = tmp;
            }
            Console.WriteLine(string.Join("
", res.Select(x => string.Join("", x))));
        }
    }
}
