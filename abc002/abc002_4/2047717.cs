// detail: https://atcoder.jp/contests/abc002/submissions/2047717
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[,] isFriend = new bool[nm[0], nm[0]];
        for (int i = 0; i < nm[1]; i++)
        {
            int[] xy = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            isFriend[xy[0], xy[1]] = true;
            isFriend[xy[1], xy[0]] = true;
        }
        List<bool> dp = new bool[]{ true, true }.ToList();
        for (int i = 1; i < nm[0]; i++)
        {
            int power = (int)Math.Pow(2, i);
            bool[] table = new bool[power];
            for (int j = 0; j < power; j++)
            {
                table[j] = false;
                if (dp[j])
                {
                    bool[] b = Convert.ToString(j, 2).Select(x => x == '1').Reverse().ToArray();
                    for (int k = 0; k < b.Length; k++)
                    {
                        if (b[k] && !isFriend[k, i]) goto end;
                    }
                    table[j] = true;
                }
                end:;
            }
            dp.AddRange(table);
        }
        int res = 0;
        for (int i = 0; i < dp.Count; i++)
        {
            if (dp[i]) res = Math.Max(res, Convert.ToString(i, 2).Count(x => x == '1'));
        }
        Console.WriteLine(res);
    }
}
