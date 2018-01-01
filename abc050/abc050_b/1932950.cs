// detail: https://atcoder.jp/contests/abc050/submissions/1932950
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] T = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int M = int.Parse(Console.ReadLine());
        int[][] PX = new int[M][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int tsum = T.Sum();
        for (int i = 0; i < M; i++)
        {
            Console.WriteLine(tsum - T[PX[i][0] - 1] + PX[i][1]);
        }
    }
}
