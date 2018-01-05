// detail: https://atcoder.jp/contests/abc001/submissions/1942799
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int vv = 89;
        if (n < 100)
        {
            vv = 0;
        }
        else if(n <= 5000)
        {
            vv = n / 100;
        }
        else if(n <= 30000)
        {
            vv = n / 1000 + 50;
        }
        else if(n <= 70000)
        {
            vv = ((n / 1000) - 30) / 5 + 80;
        }
        Console.WriteLine(vv.ToString().PadLeft(2, '0'));
    }
}
