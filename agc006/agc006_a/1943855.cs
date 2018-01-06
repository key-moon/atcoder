// detail: https://atcoder.jp/contests/agc006/submissions/1943855
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int minlength = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        for (int i = 0; i <= minlength; i++)
        {
            for (int j = i; j < minlength; j++)
            {
                if (s[j] != t[j - i]) goto end;
            }
            Console.WriteLine(minlength + i);
            return;
            end:;
        }
    }
}
