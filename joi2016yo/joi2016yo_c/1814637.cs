// detail: https://atcoder.jp/contests/joi2016yo/submissions/1814637
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] i = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[][] m = new int[i[0]][].Select(x => Console.ReadLine().Select(y => c(y)).ToArray()).ToArray();

        int mincost = int.MaxValue;
        for (int j = 1; j <= i[0] - 2; j++)
        {
            for (int k = 1; k <= i[0] - j - 1; k++)
            {
                int cost = 0;
                for (int l = 0; l < m.Length; l++)
                {
                    int color;
                    if (l < j)
                    {
                        color = -1;
                    }
                    else if (l < j + k)
                    {
                        color = 0;
                    }
                    else
                    {
                        color = 1;
                    }
                    cost += m[l].Count(x => x != color);
                }
                mincost = Math.Min(mincost, cost);
            }
        }
        Console.WriteLine(mincost);
    }
    static int c(char c)
    {
        switch (c)
        {
            case 'W':
                return -1;
            case 'B':
                return 0;
        }
        return 1;
    }
}
