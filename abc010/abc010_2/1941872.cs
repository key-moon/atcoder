// detail: https://atcoder.jp/contests/abc010/submissions/1941872
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //123456789
        // a a a a a a
        // a  a  a  a 
        Console.ReadLine();
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        int[] ans = {3, 0, 1, 0, 1, 2}; 
        foreach (var i in s)
        {
            res += ans[i % 6];
        }
        Console.WriteLine(res);
    }
}
