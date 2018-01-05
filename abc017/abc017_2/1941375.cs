// detail: https://atcoder.jp/contests/abc017/submissions/1941375
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int i = 0;
        looptop:;
        if (s.Length - i == 0) goto skipch;
        if (s[i] == 'c' && s[i + 1] == 'h') goto ch;
        skipch:;
        if (s[i] == 'o' || s[i] == 'k' || s[i] == 'u') goto c;
        Console.WriteLine("NO");
        goto end;
        ch:;
        i++;
        c:;
        i++;
        if (i < s.Length) goto looptop;
        Console.WriteLine("YES");
        end:;
    }
}
