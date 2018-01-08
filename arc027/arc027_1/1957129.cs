// detail: https://atcoder.jp/contests/arc027/submissions/1957129
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] hm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(60 - hm[1] + (17 - hm[0]) * 60);
    }
}
