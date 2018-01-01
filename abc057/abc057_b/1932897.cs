// detail: https://atcoder.jp/contests/abc057/submissions/1932897
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] abs = new int[NM[0]][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[][] cds = new int[NM[1]][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        
        for (int i = 0; i < NM[0]; i++)
        {
            int res = 0;
            int[] ab = abs[i];
            int mindist = int.MaxValue;
            for (int j = 0; j < NM[1]; j++)
            {
                int[] cd = cds[j];
                int manhatdist = (Math.Abs(cd[0] - ab[0]) + Math.Abs(cd[1] - ab[1]));
                if (manhatdist < mindist)
                {
                    mindist = manhatdist;
                    res = j + 1;
                }
            }
            Console.WriteLine(res);
        }
    }
}
