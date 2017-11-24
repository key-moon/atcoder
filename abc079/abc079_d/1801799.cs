// detail: https://atcoder.jp/contests/abc079/submissions/1801799
using System;
using System.Linq;
class P
{
    static void Main(string[] args)
    {
        int[] HW = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[][] energyTable = new int[10][];
        int[][] wall = new int[HW[0]][];
        for (int i = 0; i < 10; i++) energyTable[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        for (int i = 0; i < HW[0]; i++) wall[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        bool b = true;
        while (b)
        {
            b = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (energyTable[i][j] > energyTable[i][k] + energyTable[k][j])
                        {
                            b = true;
                            energyTable[i][j] = energyTable[i][k] + energyTable[k][j];
                        }
                    }
                }
            }
        }

        int res = 0;
        for (int i = 0; i < HW[0]; i++)
        {
            for (int j = 0; j < HW[1]; j++)
            {
                res += wall[i][j] != -1 ? energyTable[wall[i][j]][1] : 0;
            }
        }
        Console.WriteLine(res);
    }
}
