// detail: https://atcoder.jp/contests/abc019/submissions/1941277
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        char lastc = s[0];
        int seqence = 0;
        foreach (var c in s)
        {
            if (c == lastc)
            {
                seqence++;
            }
            else
            {
                Console.Write($"{lastc}{seqence}");
                lastc = c;
                seqence = 1;
            }
        }
        Console.WriteLine($"{lastc}{seqence}");
    }
}
