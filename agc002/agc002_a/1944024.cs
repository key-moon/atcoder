// detail: https://atcoder.jp/contests/agc002/submissions/1944024
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        string res = "";
        if (0 < a[0] && 0 < a[1])
        {
            res = "Positive";
        } 
        else if (0 > a[0] && 0 > a[1])
        {
            if ((a[1] - a[0]) % 2 == 1)
            {
                res = "Positive";
            }
            else
            {
                res = "Negative";
            }
        }
        else
        {
            res = "Zero";
        }
        Console.WriteLine(res);
    }
}
