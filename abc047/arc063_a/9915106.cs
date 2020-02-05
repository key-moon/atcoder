// detail: https://atcoder.jp/contests/abc047/submissions/9915106
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        char last = s[0];
        var count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (last != s[i]) count++;
            last = s[i];
        }
        Console.WriteLine(count);
    }
}
