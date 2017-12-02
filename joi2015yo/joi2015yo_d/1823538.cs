// detail: https://atcoder.jp/contests/joi2015yo/submissions/1823538
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] NM = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[] Distance = new int[NM[0]].Select(x => int.Parse(Console.ReadLine())).ToArray();
        int[] Weather = new int[NM[1]].Select(x => int.Parse(Console.ReadLine())).ToArray();
        int[,] Hard = new int[NM[1], NM[0]];
        int[,] Cost = new int[NM[1], NM[0]];

        for (int i = 0; i < NM[1]; i++)
        {
            for (int j = 0; j < NM[0]; j++)
            {
                Hard[i, j] = Weather[i] * Distance[j];
            }
        }

        Cost[0, 0] = Hard[0, 0];
        for (int i = 1; i < NM[1]; i++)
        {
            //i日目
            Cost[i, 0] = Math.Min(Hard[i, 0], Cost[i - 1, 0]);
            for (int j = 1; j <= i && j < NM[0]; j++)
            {
                Cost[i, j] = Cost[i - 1, j] != 0 ? Math.Min(Cost[i - 1, j], (Hard[i, j] + Cost[i - 1, j - 1])) : Hard[i, j] + Cost[i - 1, j - 1];
            }
        }

        Console.WriteLine(Cost[NM[1] - 1, NM[0] - 1]);
    }
}
