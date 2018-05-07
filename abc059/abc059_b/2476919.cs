// detail: https://atcoder.jp/contests/abc059/submissions/2476919
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        string s = Console.ReadLine().PadLeft(101, '0');
        string t = Console.ReadLine().PadLeft(101, '0'); ;
        int cmp = s.CompareTo(t);
        Console.WriteLine(cmp == 0 ? "EQUAL" : (cmp < 0 ? "LESS" : "GREATER"));
    }
}
