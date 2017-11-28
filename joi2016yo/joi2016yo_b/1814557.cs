// detail: https://atcoder.jp/contests/joi2016yo/submissions/1814557
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] i = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[] S = new int[i[0]].Select(x => int.Parse(Console.ReadLine())).ToArray();
        for (int j = 1; j < i[1] + 1; j++)
        {
            for (int k = 0; k < i[0] - 1; k++)
            {
                if (S[k] % j > S[k + 1] % j)
                {
                    int sk = S[k];
                    S[k] = S[k + 1];
                    S[k + 1] = sk;
                }
            }
        }
        foreach (int j in S) Console.WriteLine(j);
    }
}
