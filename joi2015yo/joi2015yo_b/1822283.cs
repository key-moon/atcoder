// detail: https://atcoder.jp/contests/joi2015yo/submissions/1822283
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[][] B = new int[m][].Select(x => Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray()).ToArray();

        int[] score = new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (B[i][j] == A[i])
                {
                    score[j]++;
                }
                else
                {
                    score[A[i] - 1]++;
                }
            }
        }
        for (int i = 0; i < n; i++) Console.WriteLine(score[i]);
    }
}
