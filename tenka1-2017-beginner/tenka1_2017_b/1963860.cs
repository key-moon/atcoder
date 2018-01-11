// detail: https://atcoder.jp/contests/tenka1-2017-beginner/submissions/1963860
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] maxab = new int[2];
        for (int i = 0; i < n; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (ab[0] > maxab[0]) maxab = ab;
        }
        Console.WriteLine(maxab.Sum());
    }
}
