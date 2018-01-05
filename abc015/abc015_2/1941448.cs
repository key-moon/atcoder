// detail: https://atcoder.jp/contests/abc015/submissions/1941448
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine((int)Math.Ceiling(Console.ReadLine().Split().Select(int.Parse).Where(x => x != 0).Average()));
    }
}
