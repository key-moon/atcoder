// detail: https://atcoder.jp/contests/abc051/submissions/2137421
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] path = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        int[][] map = Enumerable.Repeat(0, nm[0]).Select(_ => Enumerable.Repeat(int.MaxValue / 2, nm[0]).ToArray()).ToArray();
        for (int i = 0; i < path.Length; i++)
        {
            map[path[i][0] - 1][path[i][1] - 1] = path[i][2];
            map[path[i][1] - 1][path[i][0] - 1] = path[i][2];
        }

        bool flag = true;
        while (flag)
        {
            flag = false;
            for (int i = 0; i < nm[0]; i++)
            {
                for (int j = 0; j < nm[0]; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < nm[0]; k++)
                        {
                            if (k != i && k != j && map[i][j] > map[i][k] + map[k][j])
                            {
                                flag = true;
                                map[i][j] = map[i][k] + map[k][j];
                                map[j][i] = map[i][k] + map[k][j];
                            }
                        }
                    }
                }
            }
        }

        int res = 0;
        for (int i = 0; i < path.Length; i++)
        {
            if (map[path[i][0] - 1][path[i][1] - 1] < path[i][2])
            {
                res++;
            }
        }
        Console.WriteLine(res);
    }
}
