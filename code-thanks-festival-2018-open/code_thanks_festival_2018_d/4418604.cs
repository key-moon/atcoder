// detail: https://atcoder.jp/contests/code-thanks-festival-2018-open/submissions/4418604
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();

        char minChar = 'z';
        int res = 0;
        foreach (var c in s)
        {
            if(c <= minChar)
            {
                minChar = c;
                res++;
            }
        }
        Console.WriteLine(res);
    }
}
