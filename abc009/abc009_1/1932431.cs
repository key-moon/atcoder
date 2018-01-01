// detail: https://atcoder.jp/contests/abc009/submissions/1932431
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine(a / 2 + (a % 2 == 1 ? 1 : 0));
    }
}
