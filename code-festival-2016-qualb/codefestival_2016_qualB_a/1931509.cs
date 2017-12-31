// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/1931509
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        string codefestival = "CODEFESTIVAL2016";
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != codefestival[i]) res++;
        }
        Console.WriteLine(res);
    }
}
