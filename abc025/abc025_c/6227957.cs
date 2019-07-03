// detail: https://atcoder.jp/contests/abc025/submissions/6227957
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static int[][] b;
    static int[][] c;
    static void Main()
    {
        b = Enumerable.Repeat(0, 2).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        c = Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var chokudai = Solve(0);
        var chokuko = b.Sum(x => x.Sum()) + c.Sum(x => x.Sum()) - chokudai;
        Console.WriteLine(chokudai);
        Console.WriteLine(chokuko);
    }

    /// <summary>直大くんの得点を返す</summary>
    static int Solve(uint mapCode)
    {
        var popCount = PopCount(mapCode);
        if (popCount == 9)
        {
            int score = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if ((mapCode >> ((i * 3 + j) * 2) & mapCode >> ((i * 3 + j + 1) * 2) & 3) != 0)
                        score += c[i][j];
                    if ((mapCode >> ((j * 3 + i) * 2) & mapCode >> (((j + 1) * 3 + i) * 2) & 3) != 0)
                        score += b[j][i];
                }
            }
            return score;
        }
        //偶数個ならば直大くんのターン
        var isChokudaiTurn = popCount % 2 == 0;
        int result = isChokudaiTurn ? 0 : int.MaxValue;
        for (int i = 0; i < 9; i++)
        {
            if (((mapCode >> (i * 2)) & 3) == 0)
            {
                if (isChokudaiTurn) result = Max(result, Solve(mapCode | (1u << (i * 2))));
                else result = Min(result, Solve(mapCode | (2u << (i * 2))));
            }
        }
        return result;
    }

    static int PopCount(uint n)
    {
        n = n - ((n >> 1) & 0x55555555U);
        n = (n & 0x33333333U) + ((n >> 2) & 0x33333333U);
        return (int)(((n + (n >> 4) & 0xF0F0F0FU) * 0x1010101U) >> 24);
    }
}
