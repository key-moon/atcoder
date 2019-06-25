// detail: https://atcoder.jp/contests/joi2013yo/submissions/6122276
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


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            string t = Console.ReadLine();
            for (int start = 0; start < t.Length; start++)
            {
                for (int interval = 0; interval < t.Length; interval++)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (start + interval * j >= t.Length || s[j] != t[start + interval * j])
                            goto invalid;
                    }
                    res++;
                    goto end;
                invalid:;
                }
            }
        end:;
        }
        Console.WriteLine(res);
    }
}
