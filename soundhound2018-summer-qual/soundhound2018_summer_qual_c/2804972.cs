// detail: https://atcoder.jp/contests/soundhound2018-summer-qual/submissions/2804972
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long[] nmd = Console.ReadLine().Split().Select(long.Parse).ToArray();
        //差ひとつ分がその数になる確率。(/n^2)
        Console.WriteLine(((double)((nmd[0] - nmd[2]) * (nmd[2] == 0 ? 1 : 2) * (nmd[1] - 1))) / (nmd[0] * nmd[0]));
    }
}
