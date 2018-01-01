// detail: https://atcoder.jp/contests/abc043/submissions/1933061
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] NK = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string w = Console.ReadLine();
        string res = "";
        foreach (var c in w)
        {
            if (c == 'B')
            {
                if (res.Length != 0) res = res.Substring(0, res.Length - 1);
            }
            else
            {
                res += c;
            }   
        }
        Console.WriteLine(res);
    }
}
