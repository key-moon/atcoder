// detail: https://atcoder.jp/contests/abc075/submissions/1932772
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] map = new bool[HW[0] + 2][];
        map[0] = new bool[HW[1] + 2];
        map[map.Length - 1] = new bool[HW[1] + 2];
        for (int i = 1; i < HW[0] + 1; i++)
        {
            string s = $".{Console.ReadLine()}.";
            map[i] = s.Select(x => x == '#').ToArray();
        }
       
        for (int i = 0; i < HW[0]; i++)
        {
            string smap = "";
            for (int j = 0; j < HW[1]; j++)
            {
                if (map[i + 1][j + 1])
                {
                    smap += "#";
                }
                else
                {
                    int count = new bool[] { map[i][j], map[i][j + 1], map[i][j + 2], map[i + 1][j], map[i + 1][j + 1], map[i + 1][j + 2], map[i + 2][j], map[i + 2][j + 1], map[i + 2][j + 2] }.Count(x => x);
                    smap += count;
                }
            }
            Console.WriteLine(smap);
        }
    }
}
