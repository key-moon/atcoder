// detail: https://atcoder.jp/contests/ddcc2017-qual/submissions/2095564
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] L = Enumerable.Repeat(0, nc[0]).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();

        int count = 0;
        int find = 0;
        int bind = L.Length - 1;
        while (find <= bind)
        {
            if (L[bind] + L[find] < nc[1])
            {
                find++;
                bind--;
            }
            else
            {
                bind--;
            }
            count++;
        }
        Console.WriteLine(count);
    }
}
