// detail: https://atcoder.jp/contests/abc048/submissions/1932962
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] abx = Console.ReadLine().Split().Select(long.Parse).ToArray();

        Console.WriteLine(abx[1] / abx[2] - (abx[0] / abx[2] - (abx[0] % abx[2] != 0 ? 0 : 1)));
    }
}
