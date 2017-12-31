// detail: https://atcoder.jp/contests/code-festival-2016-quala/submissions/1931507
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        string res = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (i == 4) res += " ";
            res += s[i];
        }
        Console.WriteLine(res);
    }
}
