// detail: https://atcoder.jp/contests/joi2007yo/submissions/1970803
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(Math.Max(Console.ReadLine().Split().Select(int.Parse).ToArray().Sum(), Console.ReadLine().Split().Select(int.Parse).ToArray().Sum()));
    }
}
