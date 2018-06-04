// detail: https://atcoder.jp/contests/abc057/submissions/2616703
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] a = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[][] check = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[] count = new int[nm[1]];
        for (int i = 0; i < nm[0]; i++)
        {
            int min = int.MaxValue;
            int ind = -1;
            for (int j = 0; j < nm[1]; j++)
            {
                if(min > Abs(a[i][0] - check[j][0]) + Abs(a[i][1] - check[j][1]))
                {
                    ind = j;
                    min = Abs(a[i][0] - check[j][0]) + Abs(a[i][1] - check[j][1]);
                }
            }
            Console.WriteLine(ind + 1);
        }
    }
}
