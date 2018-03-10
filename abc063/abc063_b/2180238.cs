// detail: https://atcoder.jp/contests/abc063/submissions/2180238
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Distinct().Count() == s.Length?"yes":"no");
    }
}
