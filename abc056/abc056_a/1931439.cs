// detail: https://atcoder.jp/contests/abc056/submissions/1931439
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        bool a = s[0] == 'H';
        bool b = s[2] == 'H';
        if ((a && b) || (!a && !b))
        {
            Console.WriteLine("H");
        }
        else
        {
            Console.WriteLine("D");
        }
    }
}
