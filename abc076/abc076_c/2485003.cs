// detail: https://atcoder.jp/contests/abc076/submissions/2485003
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        char[] s = Console.ReadLine().ToArray();
        string t = Console.ReadLine();
        bool flag = false;
        for (int i = s.Length - t.Length; i >= 0; i--)
        {
            if (flag) goto end;
            for (int j = 0; j < t.Length; j++)
            {
                if (s[i + j] != '?' && s[i + j] != t[j]) goto end;
            }
            for (int j = 0; j < t.Length; j++)
            {
                s[i + j] = t[j];
            }
            flag = true;
            end:;
        }
        if (flag) Console.WriteLine(string.Join("", s).Replace('?', 'a'));
        else Console.WriteLine("UNRESTORABLE");
    }
}
