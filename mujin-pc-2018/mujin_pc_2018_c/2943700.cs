// detail: https://atcoder.jp/contests/mujin-pc-2018/submissions/2943700
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static int[] diry = { 1, 0, -1, 0, 1 };
    static int[] dirx = { 0, 1, 0, -1, 0 };
    static string[] s;
    static int[] yx;
    static void Main()
    {
        yx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        s = Enumerable.Repeat(0, yx[0]).Select(_ => Console.ReadLine()).ToArray();
        //まっすぐ進める距離 を持っておきたい
        //線形走査していろいろ
        int[][][] dists = Enumerable.Repeat(0, yx[0]).Select(_ => Enumerable.Repeat(0, yx[1]).Select(__ => new int[4]).ToArray()).ToArray();
        for (int i = 0; i < yx[0]; i++)
        {
            int dist = -1;
            for (int j = 0; j < yx[1]; j++)
            {
                if (s[i][j] != '.') dist = -1;
                else dist++;
                dists[i][j][2] = dist;
            }
            dist = -1;
            for (int j = yx[1] - 1; j >= 0; j--)
            {
                if (s[i][j] != '.') dist = -1;
                else dist++;
                dists[i][j][0] = dist;
            }
        }
        for (int i = 0; i < yx[1]; i++)
        {
            int dist = -1;
            for (int j = 0; j < yx[0]; j++)
            {
                if (s[j][i] != '.') dist = -1;
                else dist++;
                dists[j][i][1] = dist;
            }
            dist = -1;
            for (int j = yx[0] - 1; j >= 0; j--)
            {
                if (s[j][i] != '.') dist = -1;
                else dist++;
                dists[j][i][3] = dist;
            }
        }
        long res = 0;
        for (int i = 0; i < yx[0]; i++)
        {
            for (int j = 0; j < yx[1]; j++)
            {
                //交わっているところ
                for (int k = 1; k <= 4; k++)
                {
                    if (dists[i][j][k % 4] <= 0 || dists[i][j][k - 1] <= 0) continue;
                    res += dists[i][j][k % 4] * dists[i][j][k - 1];
                }
            }
        }
        Console.WriteLine(res);
    }
    static bool isValid(int y,int x)
    {
        if (y < 0 || yx[0] <= y || x < 0 || yx[1] <= x) return false;
        if (s[y][x] != '.') return false;
        return true;
    }
}
