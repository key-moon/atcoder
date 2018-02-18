// detail: https://atcoder.jp/contests/abc088/submissions/2108603
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
        int alice = a.Where((x, y) => y % 2 == 0).Sum();
        int bob = a.Where((x, y) => y % 2 == 1).Sum();
        Console.WriteLine(alice - bob);
    }    
}
