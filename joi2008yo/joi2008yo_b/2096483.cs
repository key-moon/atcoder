// detail: https://atcoder.jp/contests/joi2008yo/submissions/2096483
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int joi = 0;
        int ioi = 0;
        for (int i = 0; i < s.Length - 3; i++)
        {
            if (s[i + 1] == 'O' && s[i + 2] == 'I')
            {
                if (s[i] == 'J')
                {
                    joi++;
                }
                if (s[i] == 'I')
                {
                    ioi++;
                }
            }
        }
        Console.WriteLine($"{joi}
{ioi}");
    }
}
