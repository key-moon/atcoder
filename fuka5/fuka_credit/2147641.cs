// detail: https://atcoder.jp/contests/fuka5/submissions/2147641
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        while (true)
        {
            int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (nk[0] == 0) break;
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).Take(nk[1]).Sum());
        }
    }
}
