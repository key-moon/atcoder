// detail: https://atcoder.jp/contests/abc007/submissions/1954157
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] s = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        int[] g = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        int[][] map = new int[hw[0]][];
        for (int i = 0; i < hw[0]; i++)
        {
            map[i] = Console.ReadLine().Select(x => (x == '.' ? int.MaxValue : -1)).ToArray();
        }
        Queue<int[]> queue = new Queue<int[]>();
        map[s[0]][s[1]] = 0;
        queue.Enqueue(s);
        while (queue.Count != 0)
        {
            int[] n = queue.Dequeue();
            if (map[n[0]][n[1]] + 1 < map[n[0]][n[1] + 1])
            {
                map[n[0]][n[1] + 1] = map[n[0]][n[1]] + 1;
                queue.Enqueue(new int[] { n[0], n[1] + 1 });
            }
            if (map[n[0]][n[1]] + 1 < map[n[0]][n[1] - 1])
            {
                map[n[0]][n[1] - 1] = map[n[0]][n[1]] + 1;
                queue.Enqueue(new int[] { n[0], n[1] - 1 });
            }
            if (map[n[0]][n[1]] + 1 < map[n[0] + 1][n[1]])
            {
                map[n[0] + 1][n[1]] = map[n[0]][n[1]] + 1;
                queue.Enqueue(new int[] { n[0] + 1, n[1] });
            }
            if (map[n[0]][n[1]] + 1 < map[n[0] - 1][n[1]])
            {
                map[n[0] - 1][n[1]] = map[n[0]][n[1]] + 1;
                queue.Enqueue(new int[] { n[0] - 1, n[1] });
            }
        }
        Console.WriteLine(map[g[0]][g[1]]);
    }
}
