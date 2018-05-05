// detail: https://atcoder.jp/contests/abc096/submissions/2460061
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1]; j++)
            {
                if (map[i][j] == '#')
                {
                    if (!((i != 0 && map[i - 1][j] == '#') || (j != 0 && map[i][j - 1] == '#') || (i != hw[0] - 1 && map[i + 1][j] == '#') || (j != hw[1] - 1 && map[i][j + 1] == '#')))
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
        }
        Console.WriteLine("Yes");
    }
}
