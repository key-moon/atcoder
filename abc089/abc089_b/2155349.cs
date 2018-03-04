// detail: https://atcoder.jp/contests/abc089/submissions/2155349
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Distinct().Count() == 3 ? "Three" : "Four");
    }
}
