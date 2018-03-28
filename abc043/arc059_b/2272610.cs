// detail: https://atcoder.jp/contests/abc043/submissions/2272610
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        if(s[0] == s[1])
        {
            Console.WriteLine("1 2");
            return;
        }
        for (int i = 0; i < s.Length - 2; i++)
        {
            if (s[i] == s[i + 1] || s[i + 1] == s[i + 2] || s[i] == s[i + 2])
            {
                Console.WriteLine($"{i + 1} {i + 3}");
                return;
            }
        }
        Console.WriteLine("-1 -1");
    }
}
