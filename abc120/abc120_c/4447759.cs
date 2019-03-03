// detail: https://atcoder.jp/contests/abc120/submissions/4447759
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
        Console.WriteLine(Min(s.Count(x => x == '1'), s.Count(x => x == '0')) * 2);
    }
}
