// detail: https://atcoder.jp/contests/abc003/submissions/1942775
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        char[] atcoder = "@atcoder".ToCharArray();
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            if (!(s[i] == t[i] || (s[i] == '@' && atcoder.Contains(t[i])) || (t[i] == '@' && atcoder.Contains(s[i]))))
            {
                Console.WriteLine("You will lose");
                return;
            }
        }
        Console.WriteLine("You can win");
    }
}
