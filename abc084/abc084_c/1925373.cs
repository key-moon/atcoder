// detail: https://atcoder.jp/contests/abc084/submissions/1925373
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[][] CSF = new int[N - 1][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        for (int i = 0; i < CSF.Length; i++)
        {
            int nowtime = CSF[i][1] + CSF[i][0];
            for (int j = i + 1; j < CSF.Length; j++)
            {
                if (nowtime < CSF[j][1])
                {
                    nowtime = CSF[j][1];
                }
                else
                {
                    nowtime = ((nowtime / CSF[j][2]) + (nowtime % CSF[j][2] != 0 ? 1 : 0)) * CSF[j][2];
                }
                nowtime += CSF[j][0];
            }
            Console.WriteLine(nowtime);
        }
        Console.WriteLine(0);
    }
}
