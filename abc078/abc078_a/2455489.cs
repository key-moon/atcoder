// detail: https://atcoder.jp/contests/abc078/submissions/2455489
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine((s[0] == s[2] ? "=" : (s[0] < s[2] ? "<" : ">")));
    }
}
