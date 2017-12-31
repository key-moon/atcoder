// detail: https://atcoder.jp/contests/yahoo-procon2017-qual/submissions/1931537
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Contains('y') && s.Contains('a') && s.Contains('h') && s.Count(x => x == 'o') == 2 ? "YES" : "NO");
    }
}
