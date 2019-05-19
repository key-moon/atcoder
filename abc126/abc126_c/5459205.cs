// detail: https://atcoder.jp/contests/abc126/submissions/5459205
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        double res = 0;
        for (int i = 1; i <= n; i++)
        {
            int count = 0;
            while (i << count < k) count++;
            res += Pow(0.5, count);
        }
        res /= n;
        Console.WriteLine(res);
    }

}
