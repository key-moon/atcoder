// detail: https://atcoder.jp/contests/code-festival-2016-quala/submissions/5028987
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        char[] s = Console.ReadLine().ToArray();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < s.Length - 1; i++)
        {
            var distToA = ('z' - s[i] + 1) % 26;
            if (distToA <= n)
            {
                s[i] = 'a';
                n -= distToA;
            }
        }
        s[s.Length - 1] = (char)('a' + ((s[s.Length - 1] - 'a') + n) % 26);
        Console.WriteLine(string.Join("", s));
    }
}
