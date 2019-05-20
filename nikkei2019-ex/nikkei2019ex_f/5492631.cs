// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/5492631
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
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string s = "";
            for (int j = 2; j <= 6; j++) if (i % j == 0) s += (char)(95 + j);
            Console.WriteLine(s == "" ? i.ToString() : s);
        }
    }
}
