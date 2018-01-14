// detail: https://atcoder.jp/contests/agc020/submissions/1975723
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long makablePairMin = 2;
        long makablePairMax = 2;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            long possibleMinWinner = (makablePairMin / a[i] + (makablePairMin % a[i] != 0 ? 1 : 0)) * a[i];
            long possibleMaxWinner = (makablePairMax / a[i]) * a[i];
            if (possibleMaxWinner >= possibleMinWinner)
            {
                makablePairMin = possibleMinWinner;
                makablePairMax = possibleMaxWinner + a[i] - 1;
            }
            else
            {
                Console.WriteLine(-1);
                return;
            }
        }
        Console.WriteLine($"{makablePairMin} {makablePairMax}");
    }
}
