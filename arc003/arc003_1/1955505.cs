// detail: https://atcoder.jp/contests/arc003/submissions/1955505
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Select(x => Math.Max(4 - (x - 'A'),0)).Average());
    }
}
