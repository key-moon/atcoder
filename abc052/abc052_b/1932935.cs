// detail: https://atcoder.jp/contests/abc052/submissions/1932935
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        string s = Console.ReadLine();
        int max = 0;
        int x = 0;
        foreach (var c in s)
        {
            if (c == 'I') x++;
            else x--;
            max = Math.Max(x,max);
        }
        Console.WriteLine(max);
    }
}
