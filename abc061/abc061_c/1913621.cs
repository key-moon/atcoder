// detail: https://atcoder.jp/contests/abc061/submissions/1913621
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class P
{
    static void Main()
    {
        long[] NK = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
        int[][] ab = new int[NK[0]][].Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()).OrderBy(x => x[0]).ToArray();

        long nowindex = 0;
        for (int i = 0; i < ab.Length; i++)
        {
            nowindex += ab[i][1];
            if (nowindex >= NK[1])
            {
                Console.WriteLine(ab[i][0]);
                break;
            }
        }
    }
}
