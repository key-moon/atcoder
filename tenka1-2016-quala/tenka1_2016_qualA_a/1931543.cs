// detail: https://atcoder.jp/contests/tenka1-2016-quala/submissions/1931543
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int res = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 != 0 && i % 5 != 0)
            {
                res+=i;
            }
        }
        Console.WriteLine(res);
    }
}
