// detail: https://atcoder.jp/contests/abc086/submissions/9890123
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        int[][] white = Enumerable.Repeat(0, k).Select(_ => new int[k]).ToArray();
        int[][] black = Enumerable.Repeat(0, k).Select(_ => new int[k]).ToArray();
        var totalWhite = 0;
        var totalBlack = 0;
        for (int i = 0; i < n; i++)
        {
            var xyc = Console.ReadLine().Split();
            var x = int.Parse(xyc[0]);
            var y = int.Parse(xyc[1]);
            var parity = y / k + x / k;
            var c = xyc[2];
            
            if ((c == "W" && parity % 2 == 0) || 
                (c == "B" && parity % 2 == 1)) 
            { white[y % k][x % k]++; totalWhite++; }
            if ((c == "B" && parity % 2 == 0) || 
                (c == "W" && parity % 2 == 1)) 
            { black[y % k][x % k]++; totalBlack++; }
                
        }
        int[][] whiteAccum = Enumerable.Repeat(0, k + 1).Select(_ => new int[k + 1]).ToArray();
        int[][] blackAccum = Enumerable.Repeat(0, k + 1).Select(_ => new int[k + 1]).ToArray();

        for (int i = 1; i <= k; i++)
            for (int j = 1; j <= k; j++)
            {
                whiteAccum[i][j] = white[i - 1][j - 1] + whiteAccum[i][j - 1] + whiteAccum[i - 1][j] - whiteAccum[i - 1][j - 1];
                blackAccum[i][j] = black[i - 1][j - 1] + blackAccum[i][j - 1] + blackAccum[i - 1][j] - blackAccum[i - 1][j - 1];
            }

        var res = 0;
        for (int i = 0; i <= k; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                var whiteCount = whiteAccum[k][j] + whiteAccum[i][k] - whiteAccum[i][j] * 2;
                var blackCount = blackAccum[k][j] + blackAccum[i][k] - blackAccum[i][j] * 2;
                res = Max(res, Max(whiteCount + (totalBlack - blackCount), blackCount + (totalWhite - whiteCount)));
            }
        }

        Console.WriteLine(res);
    }
}
