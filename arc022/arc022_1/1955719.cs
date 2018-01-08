// detail: https://atcoder.jp/contests/arc022/submissions/1955719
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        bool I = false;
        bool C = false;
        bool T = false;
        foreach (var c in Console.ReadLine())
        {
            if (!I) I = c == 'I' || c == 'i';
            else if (!C) C = c == 'C' || c == 'c';
            else if (!T) T = c == 'T' || c == 't';
        }
        Console.WriteLine(T ? "YES" : "NO");
    }
}
