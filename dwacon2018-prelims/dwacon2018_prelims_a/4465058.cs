// detail: https://atcoder.jp/contests/dwacon2018-prelims/submissions/4465058
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Substring(0, 2) == s.Substring(2, 2) ? "Yes" : "No");
    }
}
