// detail: https://atcoder.jp/contests/abc053/submissions/2136727
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine((n / 11) * 2 + (n % 11 == 0 ? 0 : (n % 11 <= 6 ? 1 : 2)));
    }
}
