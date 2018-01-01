// detail: https://atcoder.jp/contests/abc033/submissions/1932293
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Count(x => s[0] == x) == 4 ? "SAME":"DIFFERENT");
    }
}
