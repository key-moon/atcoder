// detail: https://atcoder.jp/contests/NYC2015/submissions/2176344
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string s = Convert.ToString(int.Parse(Console.ReadLine()), 2);
        char[] rs = s.Reverse().ToArray();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != rs[i]) goto end;
        }
        Console.WriteLine("Yes");
        return;
        end: Console.WriteLine("No");
    }
}
