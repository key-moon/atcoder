// detail: https://atcoder.jp/contests/ddcc2017-qual/submissions/2095543
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(1728 * abcd[0] + 144 * abcd[1] + 12 * abcd[2] + abcd[3]);
    }
}
