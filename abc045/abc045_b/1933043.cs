// detail: https://atcoder.jp/contests/abc045/submissions/1933043
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        string u = Console.ReadLine();
        char turn = 'a';
        while (true)
        {
            switch (turn)
            {
                case 'a':
                if (s.Length == 0)
                {
                    Console.WriteLine("A"); return;
                }
                turn = s[0];
                s = s.Substring(1);
                break;
                case 'b':
                if (t.Length == 0)
                {
                    Console.WriteLine("B"); return;
                }
                turn = t[0];
                t = t.Substring(1);
                break;
                case 'c':
                if (u.Length == 0)
                {
                    Console.WriteLine("C"); return;
                }
                turn = u[0];
                u = u.Substring(1);
                break;
            }
        }
    }
}
