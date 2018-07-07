// detail: https://atcoder.jp/contests/soundhound2018-summer-qual/submissions/2803323
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
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("", s.Where((_, c) => c % n == 0)));
    }
}
