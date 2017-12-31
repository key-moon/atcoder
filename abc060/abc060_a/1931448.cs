// detail: https://atcoder.jp/contests/abc060/submissions/1931448
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string[] s = Console.ReadLine().Split();
        Console.WriteLine(s[0].Last() == s[1][0] && s[1].Last() == s[2][0] ? "YES" : "NO");
    }
}
