// detail: https://atcoder.jp/contests/abc080/submissions/1914673
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        bool[][] F = new bool[N][].Select(_ => Console.ReadLine().Split().Select(x => x == "1").ToArray()).ToArray();

        int[][] P = new int[N][].Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()).ToArray();
        int maxBenefit = int.MinValue;
        for (long i = 1; i < 1024; i++)
        {
            int[] timeCount = new int[N];
            string bitmask = Convert.ToString(i, 2).PadLeft(10,'0');
            for (int j = 0; j < 10; j++)
            {
                if (bitmask[j] == '1')
                {
                    for (int k = 0; k < F.Length; k++)
                    {
                        if (F[k][j])
                        {
                            timeCount[k]++;
                        }
                    }
                }
            }
            int benefit = 0;
            for (int j = 0; j < timeCount.Length; j++)
            {
                benefit += P[j][timeCount[j]];
            }
            maxBenefit = Math.Max(benefit, maxBenefit);
        }
        Console.WriteLine(maxBenefit);
    }
}
