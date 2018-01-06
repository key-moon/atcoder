// detail: https://atcoder.jp/contests/agc003/submissions/1943999
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string t = Console.ReadLine();
        bool n = t.Contains('N');
        bool e = t.Contains('E');
        bool w = t.Contains('W');
        bool s = t.Contains('S');
        Console.WriteLine((n && s && !e && !w) || (!n && !s && e && w) || (n && s && e && w) ? "Yes" : "No");
    }
}
