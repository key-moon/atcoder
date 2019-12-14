// detail: https://atcoder.jp/contests/abc066/submissions/8959770
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
        string s = Console.ReadLine();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            var a = s.Substring(0, i);
            if (a.Substring(a.Length / 2) == a.Substring(0, a.Length / 2))
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}
