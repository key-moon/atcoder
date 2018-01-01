// detail: https://atcoder.jp/contests/abc019/submissions/1932378
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NST = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        Console.WriteLine(NST[1]);
    }
}
