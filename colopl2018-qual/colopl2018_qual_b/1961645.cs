// detail: https://atcoder.jp/contests/colopl2018-qual/submissions/1961645
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int x = Console.ReadLine().Split().Select(int.Parse).ToArray()[1];
        string s = Console.ReadLine();

        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int a = int.Parse(Console.ReadLine());
            if (s[i] == '1')
            {
                res += Math.Min(a,x);
            }
            else
            {
                res += a;
            }
        }
        Console.WriteLine(res);
    }
}
