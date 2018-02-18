// detail: https://atcoder.jp/contests/abc088/submissions/2110475
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] map = Enumerable.Range(0, hw[0]).Select(_ => Console.ReadLine().Select(x => x == '.' ? int.MaxValue - 2 : int.MaxValue - 1).ToArray()).ToArray();
        int count = hw[0] * hw[1];
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1]; j++)
            {
                if (map[i][j] == int.MaxValue - 1)
                {
                    count--;
                }
            }
        }
        map[0][0] = 1;
        bool flag = true;
        while (flag)
        {
            flag = false;
            for (int i = 0; i < hw[0]; i++)
            {
                for (int j = 0; j < hw[1]; j++)
                {
                    if (map[i][j] != int.MaxValue - 1)
                    {
                        int min = int.MaxValue;
                        if (i != 0)
                        {
                            min = Math.Min(min, map[i - 1][j] + 1);
                        }
                        if (i != hw[0] - 1)
                        {
                            min = Math.Min(min, map[i + 1][j] + 1);
                        }
                        if (j != 0)
                        {
                            min = Math.Min(min, map[i][j - 1] + 1);
                        }
                        if (j != hw[1] - 1)
                        {
                            min = Math.Min(min, map[i][j + 1] + 1);
                        }

                        if(min < map[i][j])
                        {
                            if(i == hw[0] - 1 && j == hw[1] - 1)
                            {
                                Console.WriteLine(count - min);
                                return;
                            }
                            flag = true;
                            map[i][j] = min;
                        }
                    }
                }
            }
        }
        Console.WriteLine(-1);
    }    
}
