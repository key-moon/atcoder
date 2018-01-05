// detail: https://atcoder.jp/contests/abc014/submissions/1941815
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string bitmask = Convert.ToString(s[1], 2).PadLeft(s[0], '0');
        int res = Console.ReadLine().Split().Where((_,index) => bitmask[s[0] - index - 1] == '1').Select(int.Parse).Sum();
        Console.WriteLine(res);
    }
}
