// detail: https://atcoder.jp/contests/abc057/submissions/1931442
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Sum()%24);
    }
}
