// detail: https://atcoder.jp/contests/colopl2018-final-open/submissions/2084694
using System;
using System.Collections.Generic;
using System.Linq;
class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        if (s.Contains('B'))
        {
            long dmg = 0;
            int combo = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A') dmg += ++combo;
                else combo = 0;
            }
            long cdmg = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A') cdmg += ++combo;
                else combo = 0;
            }
            Console.WriteLine(dmg + cdmg * (a - 1));
        }
        else
        {
            long l = s.Length * a;
            Console.WriteLine(l * (l + 1) / 2);
        }
    }
}
