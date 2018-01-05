// detail: https://atcoder.jp/contests/abc016/submissions/1941443
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string res = "!";
        if (s[0] + s[1] == s[2] && s[0] - s[1] == s[2])
        {
            res = "?";
        }
        else if (s[0] - s[1] == s[2])
        {
            res = "-";
        }
        else if (s[0] + s[1] == s[2])
        {
            res = "+";
        }

        Console.WriteLine(res);
    }
}
