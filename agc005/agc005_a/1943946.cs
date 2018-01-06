// detail: https://atcoder.jp/contests/agc005/submissions/1943946
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int stacks = 0;
        int res = 0;
        foreach (var i in s)
        {
            if (i == 'S') stacks++;
            else if (stacks >= 1) stacks--;
            else res++;
        }
        Console.WriteLine(res * 2);
    }
}
