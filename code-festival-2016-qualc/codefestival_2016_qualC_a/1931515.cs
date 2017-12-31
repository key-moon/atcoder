// detail: https://atcoder.jp/contests/code-festival-2016-qualc/submissions/1931515
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int c = s.IndexOf('C');
        int f = s.LastIndexOf('F');
        if (c >= 0 && f >= 0 && f > c)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
