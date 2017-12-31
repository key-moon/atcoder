// detail: https://atcoder.jp/contests/code-festival-2017-quala/submissions/1931522
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.Length >= 4 && s.Substring(0, 4) == "YAKI" ? "Yes" : "No");
    }
}
