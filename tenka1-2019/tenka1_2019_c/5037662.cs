// detail: https://atcoder.jp/contests/tenka1-2019/submissions/5037662
using System;
using System.IO;
using System.Linq;
using System.Collections;
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
        string s = Console.ReadLine();
        int current = s.Count(x => x == '.');
        int res = current;
        for (int i = 0; i < n; i++)
        {
            current += s[i] == '#' ? 1 : -1;
            res = Min(res, current);
        }
        Console.WriteLine(res);
    }
}
