// detail: https://atcoder.jp/contests/dwango2015-prelims/submissions/4979370
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        string s = Console.ReadLine() + "  ";
        long res = 0;
        long streak = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '2' && s[i + 1] == '5')
            {
                streak++;
                i++;
            }
            else
            {
                res += streak * (streak + 1) / 2;
                streak = 0;
            }
        }
        Console.WriteLine(res);
    }
}
