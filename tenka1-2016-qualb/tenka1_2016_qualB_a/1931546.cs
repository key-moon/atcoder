// detail: https://atcoder.jp/contests/tenka1-2016-qualb/submissions/1931546
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(f(f(f(20))));
    }
    static int f(int n)
    {
        return (int)Math.Floor(((double)(n * n) + 4) / 8);
    }
}
