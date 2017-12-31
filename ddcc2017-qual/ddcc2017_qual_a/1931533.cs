// detail: https://atcoder.jp/contests/ddcc2017-qual/submissions/1931533
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s[0] == s[1] && s[2] == s[3] && s[1] != s[2] ? "Yes": "No");
    }
}
