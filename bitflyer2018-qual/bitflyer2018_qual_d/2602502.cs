// detail: https://atcoder.jp/contests/bitflyer2018-qual/submissions/2602502
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long[] hw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] hanko = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Select(x => x == '#').ToArray()).ToArray();
        //変化しなかったマス目の個数を求める。
        //1000 = 10^3

        int imosh = (int)Min(nm[0] * 2, hw[0]);
        int imosw = (int)Min(nm[1] * 2, hw[1]);

        //n*2×m*2のマスを考えればよくて、全白以外は中は黒
        //横方向についてimosの書き込みを全黒マスについて行う(1000*1000)
        int[][] imos = Enumerable.Repeat(0, imosh).Select(x => new int[imosw]).ToArray();
        for (int i = 0; i < nm[0]; i++)
        {
            for (int j = 0; j < nm[1]; j++)
            {
                if (hanko[i][j])
                {
                    imos[i][j]++;
                    if (i + (imosh - nm[0]) + 1 < imosh) imos[i + (imosh - nm[0]) + 1][j]--;
                    if (j + (imosw - nm[1]) + 1 < imosw) imos[i][j + (imosw - nm[1]) + 1]--;
                    if (i + (imosh - nm[0]) + 1 < imosh && j + (imosw - nm[1]) + 1 < imosw) imos[i + (imosh - nm[0]) + 1][j + (imosw - nm[1]) + 1]++;
                }
            }
        }
        Debug.WriteLine(string.Join("
", imos.Select(x => string.Join("", x.Select(y => y.ToString().PadLeft(2))))));
        for (int i = 0; i < imosh; i++)
        {
            for (int j = 1; j < imosw; j++)
            {
                imos[i][j] += imos[i][j - 1];
            }
        }
        for (int i = 1; i < imosh; i++)
        {
            for (int j = 0; j < imosw; j++)
            {
                imos[i][j] += imos[i - 1][j];
            }
        }

        long res = 0;
        for (int i = 0; i < imosh; i++)
        {
            for (int j = 0; j < imosw; j++)
            {
                if (imos[i][j] != 0) res++;
            }
        }
        long tateCount = imos.Sum(x => (x[nm[1] - 1] == 0 ? 0 : 1));
        long yokoCount = imos[nm[0] - 1].Sum(x => x == 0 ? 0 : 1);
        if(tateCount + yokoCount != 0) res += Max(hw[0] - nm[0] * 2, 0) * Max(hw[1] - nm[1] * 2, 0);
        res += yokoCount * Max(hw[0] - nm[0] * 2, 0);
        res += tateCount * Max(hw[1] - nm[1] * 2, 0);
        //Debug.WriteLine(string.Join("
", imos.Select(x => string.Join("", x.Select(y => y.ToString().PadLeft(2))))));
        //Debug.WriteLine(string.Join("
", imos.Select(x => string.Join("", x.Select(y => y != 0 ? "#" : ".")))));
        Console.WriteLine(res);
    }
}
