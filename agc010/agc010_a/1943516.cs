// detail: https://atcoder.jp/contests/agc010/submissions/1943516
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Count(x => x % 2 == 1) % 2 == 0 ? "YES" : "NO");
    }
}
