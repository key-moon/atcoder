// detail: https://atcoder.jp/contests/joi2009ho/submissions/2117689
using System;
using System.Linq;
using System.Collections.Generic;

class p
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.ReadLine();

        string s = Console.ReadLine();
        int res = 0;
        List<int> ioioi = new List<int>();
        int iostreak = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i - 1] != s[i])
            {
                if (iostreak == 0 && s[i] != 'O') iostreak--;
                iostreak++;
            }
            else
            {
                res += Math.Max((iostreak / 2) - n + 1, 0);
                iostreak = 0;
            }
        }
        Console.WriteLine(res);
    }
}
