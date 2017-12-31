// detail: https://atcoder.jp/contests/abc062/submissions/1931454
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[][] a = { new int[] { 1, 3, 5, 7, 8, 10, 12 }, new int[] { 4, 6, 9, 11 }, new int[] { 2 } };
        int[] s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < 3; i++)
        {
            if (a[i].Contains(s[0]) && a[i].Contains(s[1]))
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}
