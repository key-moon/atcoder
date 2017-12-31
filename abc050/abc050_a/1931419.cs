// detail: https://atcoder.jp/contests/abc050/submissions/1931419
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string[] s = Console.ReadLine().Split();
        Console.WriteLine(s[1] == "+" ? int.Parse(s[0]) + int.Parse(s[2]) : int.Parse(s[0]) - int.Parse(s[2]));
    }
}
