// detail: https://atcoder.jp/contests/agc003/submissions/2530631
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
        Console.WriteLine((s.Contains('N') ^ s.Contains('S')) || (s.Contains('W') ^ s.Contains('E')) ? "No" : "Yes");
    }
}
