// detail: https://atcoder.jp/contests/cf17-final-open/submissions/2476957
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int sins = 0;
        string s = Console.ReadLine();
        string akiba = "AKIHABARA";
        for (int i = 0; i < akiba.Length; i++)
        {
            if (i - sins < s.Length && akiba[i] == s[i - sins]) ;
            else if (akiba[i] == 'A') sins++;
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }
        if (s.Length + sins == akiba.Length)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
